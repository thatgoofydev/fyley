using System.Collections.Generic;
using System.Threading.Tasks;
using DDDCore.Domain.Aggregates;
using DDDCore.Domain.Events;

namespace DDDCore.Application.DataAccess
{
    public interface IEventStore
    {
        Task<IEnumerable<DomainEvent>> LoadEventsAsync<TIdentifier>(TIdentifier identifier, int startingFrom)
            where TIdentifier : Identifier;

        Task StoreEventsAsync<TIdentifier>(TIdentifier id, long expectedVersion, IEnumerable<DomainEvent> events)
            where TIdentifier : Identifier;
    }
}