using System;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.Submit;
using Fyley.Components.Financial.Contracts.Accounts.Commands.DefineAccount;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;
using Fyley.Components.Financial.Infrastructure.Adapters.Accounts;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.ServiceClients
{
    public class AccountServiceClient : IAccountServiceClient
    {
        private readonly IAccountServiceAdapter _serviceAdapter;

        public AccountServiceClient(IAccountServiceAdapter serviceAdapter)
        {
            _serviceAdapter = serviceAdapter;
        }

        public async Task<SubmitAccountResponse> DefineAccount(string id, SubmitAccountRequest request)
        {
            if (id == "new")
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
            
            // TODO update account details
            throw new System.NotImplementedException();
        }

        public async Task<ListAccountsResponse.AccountDto[]> ListAccounts()
        {
            var serviceResponse = await _serviceAdapter.ListAccounts(new ListAccountsRequest());
            return serviceResponse.Accounts;
        }
    }
}