using System.Linq;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.List;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.ViewModel
{
    public class AccountViewModelFactory : IAccountViewModelFactory
    {
        private readonly IAccountServiceClient _queryService;

        public AccountViewModelFactory(IAccountServiceClient serviceClient)
        {
            _queryService = serviceClient;
        }

        public async Task<ListResponse> List()
        {
            var accounts = await _queryService.ListAccounts();

            var accountViewModels = accounts.Select(account => new ListResponse.AccountViewModel
            {
                AccountId = account.AccountId,
                Name = account.Name,
                Description = account.Description,
                AccountNumber = account.AccountNumber,
                AccountNumberType = (ListResponse.AccountNumberType) account.AccountNumberType
            }).ToArray();
            
            return new ListResponse(accountViewModels);
        }
    }
}