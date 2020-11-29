using System;
using JetBrains.Annotations;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.List
{
    public class ListResponse
    {
        [UsedImplicitly] public AccountViewModel[] Accounts { get; }
        
        public ListResponse(AccountViewModel[] accounts)
        {
            Accounts = accounts;
        }

        public class AccountViewModel
        {
            public Guid AccountId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string AccountNumberType { get; set; }
            public string AccountNumber { get; set; }
        }
    }
}