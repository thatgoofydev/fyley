using System;
using System.Collections.Generic;

namespace DDDCore.Domain.ValueObjects
{
    public abstract class AggregateReference : ValueObject
    {
        public string Aggregate { get; }
        public Guid Id { get; }

        protected AggregateReference(string aggregate, Guid id)
        {
            Aggregate = aggregate;
            Id = id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Aggregate;
            yield return Id;
        }
    }
}