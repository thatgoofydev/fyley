using System;
using DDDCore.Domain.Aggregates;

namespace Fyley.Components.Financial.Domain.Accounts
{
    public class AccountId : Identifier
    {
        private const string AggregateName = "Account";
        
        public AccountId(Guid value) : base(AggregateName, value)
        { }
    }
}