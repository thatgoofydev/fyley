using System;
using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;

namespace DDDCore.Domain.Aggregates
{
    public abstract class Identifier : ValueObject
    {
        private string AggregateName { get; }
        public Guid Value { get; }

        protected Identifier(string aggregateName, Guid value)
        {
            AggregateName = aggregateName ?? throw new ArgumentNullException(nameof(aggregateName));
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return AggregateName;
            yield return Value;
        }

        public override string ToString()
        {
            return AggregateName + ":" + Value;
        }
    }
}