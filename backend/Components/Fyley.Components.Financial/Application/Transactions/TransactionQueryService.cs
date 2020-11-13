using System.Threading.Tasks;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Contracts.Transactions.ListTransactions;

namespace Fyley.Components.Financial.Application.Transactions
{
    public class TransactionQueryService : ITransactionQueryService
    {
        private readonly ITransactionQueries _transactionQueries;

        public TransactionQueryService(ITransactionQueries transactionQueries)
        {
            _transactionQueries = transactionQueries;
        }
        
        public async Task<ListTransactionsResponse> List()
        {
            var queryItems = await _transactionQueries.QueryTransactionListItems();
            return new ListTransactionsResponse
            {
                Transactions = queryItems
            };
        }
    }
}