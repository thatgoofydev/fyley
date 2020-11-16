using System.Linq;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Transactions.ViewModelFactories.Models.TransactionsOverview;
using Fyley.Components.Financial.Application.Transactions;

namespace Fyley.BFF.Desktop.Components.Financial.Transactions.ViewModelFactories
{
    public class TransactionViewModelFactory
    {
        private readonly ITransactionQueryService _queryService;

        public TransactionViewModelFactory(ITransactionQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<TransactionsOverviewResponse> GetOverviewViewModel()
        {
            var data = await _queryService.List();
            
            return new TransactionsOverviewResponse
            {
                Transactions = data.Transactions.Select(transaction =>
                {
                    var other = transaction.Amount > 0 ? transaction.Payor : transaction.Payee;
                    return new OverviewTransactionViewModel
                    {
                        TransactionId = transaction.TransactionId,
                        OtherName = other.Name,
                        OtherAccountNumber = other.AccountNumber,
                        Amount = transaction.Amount,
                        Reference = transaction.Reference,
                        OccuredOn = transaction.OccuredOn
                    };
                }).ToArray()
            };
        }
    }
}