using System;

namespace Fyley.Components.Accounts.Contracts.Service.DefineAccount
{
    public class DefineAccountRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AccountNumberType { get; set; }
        public string AccountNumber { get; set; }
        public decimal StartingBalance { get; set; }
    }
}