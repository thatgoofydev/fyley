using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Fyley.Services.Account.Application;
using Fyley.Services.Account.Domain;
using Google.Protobuf.Collections;
using Grpc.Core;

namespace Fyley.Services.Account.Bootstrapper.Grpc.Services
{
    public class AccountGrpcService : AccountService.AccountServiceBase
    {
        private readonly IAccountService _accountService;
        private readonly IAccountQueryService _accountQueryService;

        public AccountGrpcService(IAccountService accountService, IAccountQueryService accountQueryService)
        {
            _accountService = accountService;
            _accountQueryService = accountQueryService;
        }

        public override async Task<DefineAccountResponse> DefineAccount(DefineAccountRequest request, ServerCallContext context)
        {
            var accountName = new AccountName(request.Name);
            var accountDescription = new AccountDescription(request.Description);
            var accountNumberType = AccountNumberType.FromValue((int) request.AccountNumber.Type);
            var accountNumber = new Domain.AccountNumber(accountNumberType, request.AccountNumber.Value);
            
            var accountId = await _accountService.DefineAccount(accountName, accountDescription, accountNumber);

            return new DefineAccountResponse
            {
                Id = accountId.Value.ToString()
            };
        }

        public override async Task<ListAccountsResponse> ListAccounts(ListAccountsRequest request, ServerCallContext context)
        {
            var result = await _accountQueryService.ListAccounts();

            var accounts = result.Select(account => new Account
            {
                Id = account.AccountId.ToString(),
                Name = account.Name,
                Description = account.Description,
                AccountNumber = new AccountNumber
                {
                    Value = account.AccountNumberValue,
                    Type = (AccountNumber.Types.Type) account.AccountNumberType
                }
            });

            var response = new ListAccountsResponse();
            response.Accounts.AddRange(accounts);
            return response;
        }

        public override async Task<ArchiveAccountResponse> ArchiveAccount(ArchiveAccountRequest request, ServerCallContext context)
        {
            var accountId = new AccountId(Guid.Parse(request.Id));
            await _accountService.ArchiveAccount(accountId);
            return new ArchiveAccountResponse();
        }
    }
}