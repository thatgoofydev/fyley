using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.Submit;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts
{
    public interface IAccountServiceClient
    {
        Task<SubmitAccountResponse> DefineAccount(SubmitAccountRequest request);
        Task<ListAccountsResponse.AccountDto[]> ListAccounts();
    }
}