using System.Threading.Tasks;
using Fyley.Services.Account.Domain;

namespace Fyley.Services.Account.Application
{
    public interface IAccountService
    {
        Task<AccountId> DefineAccount(AccountName name, AccountDescription description, AccountNumber accountNumber);
    }
}