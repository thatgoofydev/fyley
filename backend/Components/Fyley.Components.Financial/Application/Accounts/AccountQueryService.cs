using System.Linq;
using System.Threading.Tasks;
using Fyley.Components.Financial.Application.Accounts.DataAccess;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;
using Fyley.Components.Financial.Domain.Shared;

namespace Fyley.Components.Financial.Application.Accounts
{
    public class AccountQueryService : IAccountQueryService
    {
        private readonly IAccountQueries _accountQueries;

        public AccountQueryService(IAccountQueries accountQueries)
        {
            _accountQueries = accountQueries;
        }
        
        public async Task<ListAccountsResponse> List()
        {
            var queryItems = await _accountQueries.QueryAccountListItems();

            var accounts = queryItems.Select(account => new ListAccountsResponse.AccountDto
            {
                AccountId = account.AccountId,
                Description = account.Description,
                Name = account.Name,
                AccountNumber = account.AccountNumberValue,
                AccountNumberType = account.AccountNumberType
            }).ToArray();
            
            return new ListAccountsResponse(accounts);
        }
    }
}