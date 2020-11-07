using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Components.Accounts.Domain
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }

        public Money(decimal amount)
        {
            Amount = amount;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}