using System.Threading.Tasks;
using Fyley.Components.Financial.Contracts.Accounts.AccountQueryService.ListAccounts;

namespace Fyley.Components.Financial.Application.Accounts
{
    public interface IAccountQueryService
    {
        Task<ListAccountsResponse> List();
    }
}