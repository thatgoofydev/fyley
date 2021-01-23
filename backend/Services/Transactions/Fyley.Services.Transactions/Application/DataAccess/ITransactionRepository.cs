using DDDCore.Application.DataAccess;
using Fyley.Services.Transactions.Domain;

namespace Fyley.Services.Transactions.Application.DataAccess
{
    public interface ITransactionRepository : IRepository<Transaction, TransactionId, TransactionState>
    {
    }
}