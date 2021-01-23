using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Services.Transactions.Domain
{
    public class Money : ValueObject
    {
        public decimal Amount { get; }
        public Currency Currency { get; } 

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}