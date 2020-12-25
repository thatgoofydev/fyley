using System;
using DDDCore.Domain.Aggregates;

namespace Fyley.Services.Account.Domain
{
    public class AccountId : Identifier
    {
        public AccountId(Guid value) : base(nameof(Account), value)
        { }
    }
}