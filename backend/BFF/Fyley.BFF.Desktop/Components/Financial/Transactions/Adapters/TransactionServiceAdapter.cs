using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Transactions.WebApi.Models.Submit;
using Fyley.Components.Financial.Application.Transactions;
using Fyley.Components.Financial.Contracts.Transactions.LogTransaction;

namespace Fyley.BFF.Desktop.Components.Financial.Transactions.Adapters
{
    public class TransactionServiceAdapter
    {
        private readonly ITransactionService _service;

        public TransactionServiceAdapter(ITransactionService service)
        {
            _service = service;
        }

        public async Task LogTransaction(SubmitTransactionRequest request)
        {
            await _service.LogTransaction(new LogTransactionRequest
            {
                Payor = Map(request.Payor),
                Payee = Map(request.Payee),
                Amount = request.Amount,
                Reference = request.Reference,
                OccuredOn = request.OccuredOn
            });
        }

        private static LogTransactionRequest.AccountReferenceOrTransactionAccount Map(SubmitTransactionRequest.AccountReferenceOrTransactionAccount referenceOrAccount)
        {
            if (referenceOrAccount == null) return null;
            return new LogTransactionRequest.AccountReferenceOrTransactionAccount
            {
                AccountReference = referenceOrAccount.AccountReference,
                TransactionAccount = Map(referenceOrAccount.Account)
            };
        }

        private static LogTransactionRequest.TransactionAccount Map(SubmitTransactionRequest.TransactionAccount account)
        {
            if (account == null) return null;
            return new LogTransactionRequest.TransactionAccount
            {
                Name = account.Name,
                AccountNumber = account.AccountNumber
            };
        }
    }
}