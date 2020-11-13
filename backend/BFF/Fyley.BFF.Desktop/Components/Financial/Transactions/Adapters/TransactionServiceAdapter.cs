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
                Payor = request.Payor,
                Payee = request.Payee,
                Amount = request.Amount,
                Reference = request.Reference,
                OccuredOn = request.OccuredOn
            });
        }
    }
}