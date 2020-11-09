using System.Threading.Tasks;
using Fyley.Components.Accounts.Contracts.Service.DefineAccount;

namespace Fyley.Components.Accounts.Application
{
    public interface IAccountsService
    {
        Task<DefineAccountResponse> DefineAccount(DefineAccountRequest request);
    }
}