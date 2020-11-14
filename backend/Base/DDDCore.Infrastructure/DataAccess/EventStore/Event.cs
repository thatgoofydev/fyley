using System;
using DDDCore.Domain.Events;
using Newtonsoft.Json;

namespace DDDCore.Infrastructure.DataAccess.EventStore
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string AggregateId { get; set; }
        public long AggregateVersion { get; set; }
        public string EventType { get; set; }
        public string EventJson { get; set; }
        public DateTime Created { get; set; }

        public Event()
        { }
        
        public Event(string aggregateId, DomainEvent @event)
        {
            EventId = Guid.NewGuid();
            AggregateId = aggregateId;
            AggregateVersion = @event.Metadata.AggregateSequenceNumber;
            EventType = @event.AggregateEvent.GetType().Name;
            EventJson = JsonConvert.SerializeObject(@event.AggregateEvent);
            Created = @event.Metadata.Created;
        }
    }
}