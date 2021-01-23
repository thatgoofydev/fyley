using System;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Services.Transactions.Domain
{
    public class AccountReference : AggregateReference
    {
        public AccountReference(Guid value) : base("Account", value)
        { }
    }
}