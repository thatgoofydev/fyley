﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDCore.Application.DataAccess;
using DDDCore.Domain.Aggregates;
using DDDCore.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace DDDCore.Infrastructure.DataAccess.EventStore
{
    public class EventStoreBase : IEventStore
    {
        private readonly DbSet<Event> _repository;

        public EventStoreBase(DbSet<Event> repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<DomainEvent>> LoadEventsAsync<TIdentifier>(TIdentifier identifier, int startingFrom) where TIdentifier : Identifier
        {
            // var events = await _repository.Where(efEvent =>
            //         efEvent.AggregateId == identifier.ToString() && efEvent.AggregateVersion >= startingFrom)
            //     .ToListAsync();
            // TODO transform to DomainEvent
            return Task.FromResult(new DomainEvent[0].AsEnumerable());
        }

        public async Task StoreEventsAsync<TIdentifier>(TIdentifier id, long expectedVersion, IEnumerable<DomainEvent> events) where TIdentifier : Identifier
        {
            var efEvents = events.Select(@event => new Event(id.ToString(), @event));
            await _repository.AddRangeAsync(efEvents);
        }
    }
    // public abstract class EventStoreBase : IEventStore
    // {
    //     private const int SliceSize = 200;
    //     private readonly IEventStoreConnectionStringProvider _connectionStringProvider;
    //     private readonly IEventConverter _eventConverter;
    //
    //     protected EventStoreBase(IEventStoreConnectionStringProvider connectionStringProvider, IEventConverter eventConverter)
    //     {
    //         _connectionStringProvider = connectionStringProvider;
    //         _eventConverter = eventConverter;
    //     }
    //
    //     public async Task<IEnumerable<IDomainEvent>> LoadEventsAsync<TIdentifier>(TIdentifier identifier, int startingFrom)
    //         where TIdentifier : Identifier
    //     {
    //         using var conn = await GetConnection();
    //
    //         var events = new List<IDomainEvent>();
    //         bool done;
    //         do
    //         {
    //             var slice = await conn.ReadStreamEventsForwardAsync(identifier.ToString(), startingFrom, SliceSize, false);
    //             switch (slice.Status)
    //             {
    //                 case SliceReadStatus.Success:
    //                     events.AddRange(slice.Events.Select(@event => TransformRecordedEventToDomainEvent(@event.Event)));
    //                     break;
    //                 case SliceReadStatus.StreamDeleted:
    //                 case SliceReadStatus.StreamNotFound:
    //                     throw new AggregateException("Not found"); // TODO replace
    //                 default:
    //                     throw new ArgumentOutOfRangeException();
    //             }
    //
    //             done = slice.IsEndOfStream;
    //         } while (!done);
    //
    //         return events;
    //     }
    //
    //     public async Task StoreEventsAsync<TIdentifier>(TIdentifier id, long expectedVersion, IEnumerable<IDomainEvent> events)
    //         where TIdentifier : Identifier
    //     {
    //         using var conn = await GetConnection();
    //         
    //         var eventDatas= events.Select(TransformDomainEventToEventData);
    //         await conn.AppendToStreamAsync(id.ToString(), expectedVersion, eventDatas);
    //     }
    //
    //     private EventData TransformDomainEventToEventData(IDomainEvent @event)
    //     {
    //         var eventJson = JsonConvert.SerializeObject(@event.AggregateEvent);
    //         var metaJson = JsonConvert.SerializeObject(@event.Metadata);
    //
    //         var eventData = Encoding.UTF8.GetBytes(eventJson);
    //         var metaData = Encoding.UTF8.GetBytes(metaJson);
    //
    //         return new EventData(Guid.NewGuid(), _eventConverter.GetEventType(@event), true, eventData, metaData);
    //     }
    //     
    //     private IDomainEvent TransformRecordedEventToDomainEvent(RecordedEvent recorded)
    //     {
    //         var eventJson = Encoding.UTF8.GetString(recorded.Data);
    //         var metaJson = Encoding.UTF8.GetString(recorded.Metadata);
    //
    //         var meta = JsonConvert.DeserializeObject<Metadata>(metaJson);
    //         return _eventConverter.Convert(recorded.EventType, eventJson, meta);
    //     }
    //     
    //     private async Task<IEventStoreConnection> GetConnection()
    //     {
    //         var conn = EventStoreConnection.Create(_connectionStringProvider.GetConnectionString());
    //         await conn.ConnectAsync();
    //         return conn;
    //     }
    // }
}