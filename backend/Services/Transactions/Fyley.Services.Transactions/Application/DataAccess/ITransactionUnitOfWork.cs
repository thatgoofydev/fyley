using DDDCore.Application.DataAccess;

namespace Fyley.Services.Transactions.Application.DataAccess
{
    public interface ITransactionUnitOfWork : IUnitOfWork
    {
        ITransactionRepository TransactionRepo { get; }
    }
}