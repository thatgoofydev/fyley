using System;

namespace Fyley.Components.Financial.Contracts.Accounts.AccountQueryService.ListAccounts
{
    public class ListAccountsResponse
    {
        public AccountDto[] Accounts { get; }

        public ListAccountsResponse(AccountDto[] accounts)
        {
            Accounts = accounts;
        }

        public class AccountDto
        {
            public Guid AccountId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string AccountNumberType { get; set; }
            public string AccountNumber { get; set; }
        }
    }
}