using DDDCore.Domain.Aggregates;

namespace DDDCore.Application.Errors
{
    public class AggregateNotFound : ApplicationError
    {
        public AggregateNotFound(Identifier aggregateId) : this(aggregateId.ToString())
        { }
        
        public AggregateNotFound(string aggregateId) : base($"Could not find aggregate with id '{aggregateId}'")
        { }
    }
}