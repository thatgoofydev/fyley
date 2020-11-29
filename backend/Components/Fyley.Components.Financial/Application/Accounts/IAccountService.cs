using System.Threading.Tasks;
using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Shared;

namespace Fyley.Components.Financial.Application.Accounts
{
    public interface IAccountService
    {
        Task<AccountId> DefineAccount(AccountName name, AccountDescription description, AccountNumber accountNumber);
    }
}