using System.Threading.Tasks;
using DDDCore.Infrastructure.DataAccess;
using Fyley.Components.Accounts.Application.DataAccess;
using Fyley.Components.Accounts.Domain;

namespace Fyley.Components.Accounts.Infrastructure.DataAccess
{
    public class AccountRepository : RepositoryBase<Account, AccountId, AccountState>, IAccountRepository
    {
        public AccountRepository(AccountsContext context) : base(context, context.Accounts, "AccountId")
        { }

        protected override async Task<AccountState> FetchState(AccountId id)
        {
            return await Repository.FindAsync(id.Value);
        }
    }
}