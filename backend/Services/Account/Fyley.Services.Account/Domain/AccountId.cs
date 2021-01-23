using System;
using DDDCore.Domain.Aggregates;

namespace Fyley.Services.Account.Domain
{
    public class AccountId : Identifier
    {
        private const string AggregateName = "Account";
        
        public AccountId(Guid value) : base(AggregateName, value)
        { }
    }
}