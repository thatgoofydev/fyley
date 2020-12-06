using System.Threading.Tasks;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;

namespace Fyley.Components.Financial.Application.Accounts
{
    public interface IAccountQueryService
    {
        Task<ListAccountsResponse> List();
    }
}