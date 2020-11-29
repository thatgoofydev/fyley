using System;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.Submit;
using Fyley.Components.Financial.Application.Accounts;
using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Shared;
using AccountNumberType = Fyley.Components.Financial.Domain.Shared.AccountNumberType;
using SubmitAccountNumberType = Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.Submit.AccountNumberType;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.Adapters
{
    public class AccountServiceAdapter
    {
        private readonly IAccountService _accountService;

        public AccountServiceAdapter(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<SubmitAccountResponse> DefineAccount(SubmitAccountRequest request)
        {
            var id = await _accountService.DefineAccount(
                new AccountName(request.Name),
                new AccountDescription(request.Description),
                new AccountNumber(MapToDomain(request.AccountNumberType), request.AccountNumber)
            );
            return new SubmitAccountResponse(id.Value);
        }

        private static AccountNumberType MapToDomain(SubmitAccountNumberType requestAccountNumberType)
        {
            return requestAccountNumberType switch
            {
                SubmitAccountNumberType.Iban => AccountNumberType.Iban,
                SubmitAccountNumberType.Other => AccountNumberType.Other,
                _ => throw new ArgumentException("Invalid account number type.")
            };
        }
    }
}