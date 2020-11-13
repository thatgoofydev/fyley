using System.Threading.Tasks;
using Fyley.Components.Financial.Contracts.Transactions.ListTransactions;

namespace Fyley.Components.Financial.Application.Transactions
{
    public interface ITransactionQueryService
    {
        Task<ListTransactionsResponse> List();
    }
}