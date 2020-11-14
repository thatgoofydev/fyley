using System.Threading.Tasks;
using Fyley.Components.Financial.Application.Transactions.DataAccess.QueryModels;

namespace Fyley.Components.Financial.Application.Transactions.DataAccess
{
    public interface ITransactionQueries
    {
        Task<ListTransactionsQueryModel[]> QueryTransactionListItems();
    }
}