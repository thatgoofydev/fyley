using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.Submit;
using Fyley.Components.Financial.Contracts.Accounts.Commands.DefineAccount;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;
using Fyley.Components.Financial.Infrastructure.Adapters.Accounts;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts
{
    public class AccountServiceClient : IAccountServiceClient
    {
        private readonly IAccountServiceAdapter _serviceAdapter;

        public AccountServiceClient(IAccountServiceAdapter serviceAdapter)
        {
            _serviceAdapter = serviceAdapter;
        }

        public async Task<SubmitAccountResponse> DefineAccount(SubmitAccountRequest request)
        {
            var serviceResponse = await _serviceAdapter.DefineAccount(new DefineAccountRequest
            {
                Name = request.Name,
                Description = request.Description,
                AccountNumber = request.AccountNumber,
                AccountNumberType = (int) request.AccountNumberType
            });
                
            return new SubmitAccountResponse(serviceResponse.Id);
        }

        public async Task<ListAccountsResponse.AccountDto[]> ListAccounts()
        {
            var serviceResponse = await _serviceAdapter.ListAccounts(new ListAccountsRequest());
            return serviceResponse.Accounts;
        }
    }
}