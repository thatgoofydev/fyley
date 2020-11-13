using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;
using JetBrains.Annotations;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class OptionalReference : ValueObject
    {
        public string Value { get; }

        public OptionalReference([CanBeNull] string value)
        {
            Value = value;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}