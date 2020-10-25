namespace DDDCore.Domain.Events
{
    public class DomainEvent
    {
        public IAggregateEvent AggregateEvent { get; }
        public Metadata Metadata { get; }

        public DomainEvent(IAggregateEvent aggregateEvent, Metadata metadata)
        {
            AggregateEvent = aggregateEvent;
            Metadata = metadata;
        }
    }
}