using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Components.Financial.Domain.Transactions
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