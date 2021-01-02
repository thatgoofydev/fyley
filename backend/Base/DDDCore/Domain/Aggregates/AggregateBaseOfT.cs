using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DDDCore.Domain.Events;

namespace DDDCore.Domain.Aggregates
{
    public class AggregateBase<TIdentifier, TState>
        where TIdentifier : Identifier
        where TState : class, IAggregateState
    {
        private readonly Dictionary<Type, Delegate> _eventAppliers = new Dictionary<Type, Delegate>();
        private readonly Dictionary<Type, MethodInfo> _eventApplierMethods = new Dictionary<Type, MethodInfo>();
        private readonly ICollection<IAggregateEvent> _uncommitedEvents = new LinkedList<IAggregateEvent>();
        
        public TIdentifier Id { get; }
        public TState State { get; }
        public long Version { get; private set; }

        protected AggregateBase()
        {
            Id = (TIdentifier) Activator.CreateInstance(typeof(TIdentifier), Guid.NewGuid());
            State = Activator.CreateInstance<TState>();
            Version = -1;
            RegisterEventAppliers();
        }

        protected AggregateBase(TIdentifier id, TState state, long version) : this()
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            State = state ?? throw new ArgumentNullException(nameof(state));
            Version = version >= -1 ? version : throw new ArgumentException("Cannot create an entity with version lower than -1.", nameof(version));
        }
        
        public DomainEvent[] FlushUncommitedEvents()
        {
            var events = _uncommitedEvents.ToArray()
                .Select(@event => new DomainEvent(@event, new Metadata(++Version)))
                .ToArray();
            _uncommitedEvents.Clear();
            return events;
        }
        
        public void Replay(DomainEvent[] events)
        {
            foreach (var @event in events)
            {
                if (Version + 1 != @event.Metadata.AggregateSequenceNumber)
                    throw new InvalidOperationException("Invalid aggregate version.");
                
                ApplyEvent(@event.AggregateEvent);
                Version += 1;
            }
        }
        
        protected void Emit(IAggregateEvent @event)
        {
            _uncommitedEvents.Add(@event);
            ApplyEvent(@event);
        }

        private void ApplyEvent(IAggregateEvent @event)
        {
            _eventApplierMethods[@event.GetType()].Invoke(State, new object[] { @event });
            // _eventAppliers[@event.GetType()]?.DynamicInvoke(@event);
        }
        
        private void RegisterEventAppliers()
        {
            var emitInterfaces = typeof(TState)
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandle<>));

            foreach (var emitInterface in emitInterfaces)
            {
                var aggregateEventType = emitInterface.GenericTypeArguments.First();
                var applyMethod = emitInterface.GetMethod(nameof(IHandle<IAggregateEvent>.Apply));
                _eventApplierMethods.Add(aggregateEventType, applyMethod);
                
                // var delegateType = typeof(Action<>).MakeGenericType(aggregateEventType);
                // var action = Delegate.CreateDelegate(delegateType, State, applyMethod ?? throw new InvalidOperationException());
                // _eventAppliers.Add(aggregateEventType, action);
            }
        }
    }
}