using System.Threading.Tasks;
using Fyley.Components.Financial.Contracts.Accounts.Commands.DefineAccount;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;

namespace Fyley.Components.Financial.Infrastructure.Adapters.Accounts
{
    public interface IAccountServiceAdapter
    {
        Task<DefineAccountResponse> DefineAccount(DefineAccountRequest request);

        Task<ListAccountsResponse> ListAccounts(ListAccountsRequest request);
    }
}