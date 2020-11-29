using DDDCore.Application.DataAccess;
using Fyley.Components.Financial.Domain.Accounts;

namespace Fyley.Components.Financial.Application.Accounts.DataAccess
{
    public interface IAccountRepository : IRepository<Account, AccountId, AccountState>
    {
    }
}