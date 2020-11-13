using System.Threading.Tasks;
using DDDCore.Infrastructure.DataAccess;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Domain.Transactions;

namespace Fyley.Components.Financial.Infrastructure.DataAccess.Transactions
{
    public class TransactionRepository : RepositoryBase<Transaction, TransactionId, TransactionState>, ITransactionRepository
    {
        
        public TransactionRepository(FinancialContext context) : base(context, context.Transactions, "TransactionId")
        {
        }

        protected override async Task<TransactionState> FetchState(TransactionId id)
        {
            return await Repository.FindAsync(id.Value);
        }
    }
}