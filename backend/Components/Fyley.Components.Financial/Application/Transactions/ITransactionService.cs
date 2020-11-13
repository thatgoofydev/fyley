using System.Threading.Tasks;
using Fyley.Components.Financial.Contracts.Transactions.LogTransaction;

namespace Fyley.Components.Financial.Application.Transactions
{
    public interface ITransactionService
    {
        Task<LogTransactionResponse> LogTransaction(LogTransactionRequest request);
    }
}