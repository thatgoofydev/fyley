using System.Threading.Tasks;
using Fyley.BFF.Desktop.Financial.Accounts.Models.ArchiveAccount;
using Fyley.Services.Account;

namespace Fyley.BFF.Desktop.Financial.Accounts.Adapters
{
    public class ArchiveAccountAdapter
    {
        private readonly AccountService.AccountServiceClient _accountServiceClient;

        public ArchiveAccountAdapter(AccountService.AccountServiceClient accountServiceClient)
        {
            _accountServiceClient = accountServiceClient;
        }
        
        public async Task Handle(ArchiveAccountInputModel request)
        {
            await _accountServiceClient.ArchiveAccountAsync(new ArchiveAccountRequest
            {
                Id = request.AccountId
            });
        }
    }
}