namespace DDDCore.Domain.Events
{
    public interface IHandle<in TAggregateEvent>
        where TAggregateEvent : IAggregateEvent
    {
        void Apply(TAggregateEvent @event);
    }
}