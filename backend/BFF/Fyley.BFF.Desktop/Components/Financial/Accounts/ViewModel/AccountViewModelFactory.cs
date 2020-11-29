using System.Linq;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.List;
using Fyley.Components.Financial.Application.Accounts;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.ViewModel
{
    public class AccountViewModelFactory
    {
        private readonly IAccountQueryService _queryService;

        public AccountViewModelFactory(IAccountQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<ListResponse> List()
        {
            var data = await _queryService.List();

            var accountViewModels = data.Accounts.Select(account => new ListResponse.AccountViewModel
            {
                AccountId = account.AccountId,
                Name = account.Name,
                Description = account.Description,
                AccountNumber = account.AccountNumber,
                AccountNumberType = account.AccountNumberType
            }).ToArray();
            
            return new ListResponse(accountViewModels);
        }
    }
}