using System;
using DDDCore.Domain.Aggregates;

namespace Fyley.Components.Accounts.Domain
{
    public class AccountId : Identifier
    {
        private const string AggregateName = "Account";
        
        public AccountId(Guid value) : base(AggregateName, value)
        { }
    }
}