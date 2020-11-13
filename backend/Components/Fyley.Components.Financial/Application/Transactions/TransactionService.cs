using System.Threading.Tasks;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Contracts.Transactions.LogTransaction;
using Fyley.Components.Financial.Domain.Shared;
using Fyley.Components.Financial.Domain.Transactions;

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
            var payor = new AccountNumber(AccountNumberType.Iban, request.Payor);
            var payee = new AccountNumber(AccountNumberType.Iban, request.Payee);
            var amount = new Money(request.Amount);
            var optionalReference = new OptionalReference(request.Reference);
            var occuredOn = new TransactionDateTime(request.OccuredOn);
            
            var transaction = new Transaction(payor, payee, amount, optionalReference, occuredOn);

            await _repository.AddAsync(transaction);
            await _unitOfWork.Commit();
            
            return new LogTransactionResponse();
        }
    }
}