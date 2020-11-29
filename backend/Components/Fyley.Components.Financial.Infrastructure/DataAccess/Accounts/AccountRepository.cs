using System.Threading.Tasks;
using DDDCore.Infrastructure.DataAccess;
using Fyley.Components.Financial.Application.Accounts.DataAccess;
using Fyley.Components.Financial.Domain.Accounts;

namespace Fyley.Components.Financial.Infrastructure.DataAccess.Accounts
{
    public class AccountRepository : RepositoryBase<Account, AccountId, AccountState>, IAccountRepository
    {
        public AccountRepository(FinancialContext context) : base(context, context.Accounts, nameof(AccountId))
        {
        }

        protected override async Task<AccountState> FetchState(AccountId id)
        {
            return await Repository.FindAsync(id.Value);
        }
    }
}