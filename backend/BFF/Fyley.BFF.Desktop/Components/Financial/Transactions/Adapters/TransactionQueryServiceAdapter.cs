using System.Linq;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Transactions.WebApi.Models.List;
using Fyley.Components.Financial.Application.Transactions;

namespace Fyley.BFF.Desktop.Components.Financial.Transactions.Adapters
{
    public class TransactionQueryServiceAdapter
    {
        private readonly ITransactionQueryService _service;

        public TransactionQueryServiceAdapter(ITransactionQueryService service)
        {
            _service = service;
        }

        public async Task<ListTransactionsResponse> ListTransactions()
        {
            var response = await _service.List();
            
            return new ListTransactionsResponse
            {
                Transactions = response.Transactions.Select(transaction => new ListTransactionDto
                {
                    Payor = transaction.Payor,
                    Payee = transaction.Payee,
                    Amount = transaction.Amount,
                    Reference = transaction.Reference,
                    OccuredOn = transaction.OccuredOn,
                    LoggedOn = transaction.LoggedOn
                }).ToArray()
            };
        }
    }
}