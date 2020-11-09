using DDDCore.Application.DataAccess;
using Fyley.Components.Accounts.Domain;

namespace Fyley.Components.Accounts.Application.DataAccess
{
    public interface IAccountRepository : IRepository<Account, AccountId, AccountState>
    {
        
    }
}