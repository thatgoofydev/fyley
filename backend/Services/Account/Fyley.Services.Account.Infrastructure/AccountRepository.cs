using System.Threading.Tasks;
using DDDCore.Infrastructure.DataAccess;
using Fyley.Services.Account.Application;
using Fyley.Services.Account.Application.DataAccess;
using Fyley.Services.Account.Domain;

namespace Fyley.Services.Account.Infrastructure
{
    public class AccountRepository : RepositoryBase<Domain.Account, AccountId, AccountState>, IAccountRepository
    {
        public AccountRepository(AccountDbContext context) : base(context, context.Accounts, nameof(AccountId))
        {
        }

        protected override async Task<AccountState> FetchState(AccountId id)
        {
            return await Repository.FindAsync(id.Value);
        }
    }
}