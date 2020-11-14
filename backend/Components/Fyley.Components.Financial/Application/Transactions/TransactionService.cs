using System.Threading.Tasks;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Contracts.Transactions.LogTransaction;
using Fyley.Components.Financial.Domain.Shared;
using Fyley.Components.Financial.Domain.Transactions;
using AccountReferenceOrTransactionAccount = Fyley.Components.Financial.Domain.Transactions.AccountReferenceOrTransactionAccount;

namespace Fyley.Components.Financial.Application.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IFinancialUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository repository, IFinancialUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<LogTransactionResponse> LogTransaction(LogTransactionRequest request)
        {
            var payor = MapFromContract(request.Payor);
            var payee = MapFromContract(request.Payee);
            var amount = new Money(request.Amount);
            var optionalReference = new OptionalReference(request.Reference);
            var occuredOn = new TransactionDateTime(request.OccuredOn);
            
            var transaction = new Transaction(payor, payee, amount, optionalReference, occuredOn);

            await _repository.AddAsync(transaction);
            await _unitOfWork.Commit();
            
            return new LogTransactionResponse();
        }

        private AccountReferenceOrTransactionAccount MapFromContract(LogTransactionRequest.AccountReferenceOrTransactionAccount account)
        {
            if (account.AccountReference != null)
            {
                return new AccountReferenceOrTransactionAccount(new AccountReference(account.AccountReference), null);
            }

            return new AccountReferenceOrTransactionAccount(null, new TransactionAccount(
                new AccountName(account.TransactionAccount.Name),
                account.TransactionAccount.AccountNumber == null ? null : new AccountNumber(AccountNumberType.Iban, account.TransactionAccount.AccountNumber)
            ));

        }
    }
}