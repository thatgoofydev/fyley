using System;

namespace DDDCore.Domain.Events
{
    public class Metadata
    {
        public long AggregateSequenceNumber { get; }
        public DateTime Created { get; }

        public Metadata(long aggregateSequenceNumber)
        {
            AggregateSequenceNumber = aggregateSequenceNumber;
            Created = DateTime.Now;
        }
    }
}