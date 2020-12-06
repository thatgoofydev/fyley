using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.Models.List
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
            public AccountNumberType AccountNumberType { get; set; }
            public string AccountNumber { get; set; }
        }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AccountNumberType
        {
            Other = 1,
            Iban = 2
        }
    }
}