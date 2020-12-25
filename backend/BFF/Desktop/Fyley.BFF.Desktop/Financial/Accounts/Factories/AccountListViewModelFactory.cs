using System.Linq;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Financial.Accounts.Models.AccountList;
using Fyley.Services.Account;
using Google.Protobuf.WellKnownTypes;
using AccountNumber = Fyley.BFF.Desktop.Financial.Accounts.Models.AccountList.AccountNumber;
using GrpcAccountNumberType = Fyley.Services.Account.AccountNumber.Types.Type;

namespace Fyley.BFF.Desktop.Financial.Accounts.Factories
{
    public class AccountListViewModelFactory
    {
        private readonly AccountService.AccountServiceClient _accountServiceClient;

        public AccountListViewModelFactory(AccountService.AccountServiceClient accountServiceClient)
        {
            _accountServiceClient = accountServiceClient;
        }

        public async Task<AccountListViewModel> Create()
        {
            var mask = new FieldMask();
            mask.Paths.Add("id");
            mask.Paths.Add("name");
            
            var result = await _accountServiceClient.ListAccountsAsync(new ListAccountsRequest
            {
                FieldMask = mask 
            });

            var accounts = result.Accounts.Select(account => new AccountDto
            {
                AccountId = account.Id,
                Name = account.Name,
                Description = account.Description,
                AccountNumber = new AccountNumber()
                {
                    Value = account.AccountNumber.Value,
                    Type = Map(account.AccountNumber.Type)
                }
            }).ToArray();
            
            return new AccountListViewModel
            {
                Accounts = accounts
            };
        }
        
        private static AccountNumberType Map(GrpcAccountNumberType type)
        {
            return type switch
            {
                GrpcAccountNumberType.Iban => AccountNumberType.Iban,
                GrpcAccountNumberType.Other => AccountNumberType.Other,
                _ => AccountNumberType.Other
            };
        }
        
    }
}