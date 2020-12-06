using System.Threading.Tasks;
using Fyley.Components.Financial.Application.Accounts;
using Fyley.Components.Financial.Contracts.Accounts.Commands.DefineAccount;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;
using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Shared;

namespace Fyley.Components.Financial.Infrastructure.Adapters.Accounts
{
    public class AccountServiceAdapter : IAccountServiceAdapter
    {
        private readonly IAccountService _accountService;
        private readonly IAccountQueryService _queryService;

        public AccountServiceAdapter(IAccountService accountService, IAccountQueryService queryService)
        {
            _accountService = accountService;
            _queryService = queryService;
        }

        public async Task<DefineAccountResponse> DefineAccount(DefineAccountRequest request)
        {
            var id = await _accountService.DefineAccount(
                new AccountName(request.Name),
                new AccountDescription(request.Description),
                new AccountNumber(AccountNumberType.FromValue(request.AccountNumberType), request.AccountNumber)
            );
            
            return new DefineAccountResponse
            {
                Id = id.Value
            };
        }

        public Task<ListAccountsResponse> ListAccounts(ListAccountsRequest request)
        {
            return _queryService.List();
        }
    }
}