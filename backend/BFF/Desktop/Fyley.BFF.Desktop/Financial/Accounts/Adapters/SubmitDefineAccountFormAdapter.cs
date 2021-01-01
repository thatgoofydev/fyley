using System;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Financial.Accounts.Models.DefineAccountForm;
using Fyley.Services.Account;
using AccountNumber = Fyley.Services.Account.AccountNumber;

namespace Fyley.BFF.Desktop.Financial.Accounts.Adapters
{
    public class SubmitDefineAccountFormAdapter
    {
        private readonly AccountService.AccountServiceClient _accountServiceClient;

        public SubmitDefineAccountFormAdapter(AccountService.AccountServiceClient accountServiceClient)
        {
            _accountServiceClient = accountServiceClient;
        }

        public async Task<DefineAccountFormResponse> Handle(AccountFormViewModel request)
        {
            // TODO validate request
            
            var result = await _accountServiceClient.DefineAccountAsync(new DefineAccountRequest()
            {
                Name = request.Name,
                Description = request.Description,
                AccountNumber = new AccountNumber()
                {
                    Value = request.AccountNumber.Value,
                    Type = Map(request.AccountNumber.Type) 
                }
            });

            return new DefineAccountFormResponse
            {
                AccountId = result.Id
            };
        }
        
        private static AccountNumber.Types.Type Map(AccountNumberType type)
        {
            return type switch
            {
                AccountNumberType.Iban => AccountNumber.Types.Type.Iban,
                AccountNumberType.Other => AccountNumber.Types.Type.Other,
                _ => AccountNumber.Types.Type.Unknown
            };
        }
    }
}