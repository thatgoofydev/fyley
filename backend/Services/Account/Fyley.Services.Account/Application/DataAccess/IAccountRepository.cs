using DDDCore.Application.DataAccess;
using Fyley.Services.Account.Domain;

namespace Fyley.Services.Account.Application.DataAccess
{
    public interface IAccountRepository : IRepository<Domain.Account, AccountId, AccountState>
    {        
    }
}