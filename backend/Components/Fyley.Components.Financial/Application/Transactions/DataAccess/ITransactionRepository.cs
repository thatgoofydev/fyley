using DDDCore.Application.DataAccess;
using Fyley.Components.Financial.Domain.Transactions;

namespace Fyley.Components.Financial.Application.Transactions.DataAccess
{
    public interface ITransactionRepository : IRepository<Transaction, TransactionId, TransactionState>
    {
    }
}