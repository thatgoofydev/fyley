using System.Threading.Tasks;
using Fyley.Components.Financial.Contracts.Transactions.ListTransactions;

namespace Fyley.Components.Financial.Application.Transactions.DataAccess
{
    public interface ITransactionQueries
    {
        Task<TransactionListDto[]> QueryTransactionListItems();
    }
}