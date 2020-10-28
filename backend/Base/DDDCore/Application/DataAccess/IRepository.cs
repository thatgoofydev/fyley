using System.Threading.Tasks;
using DDDCore.Domain.Aggregates;

namespace DDDCore.Application.DataAccess
{
    public interface IRepository<TAggregate, in TIdentifier, TState>
        where TAggregate : AggregateBase<TIdentifier, TState>
        where TIdentifier : Identifier
        where TState : class, IAggregateState
    {
        Task<TAggregate> FetchAsync(TIdentifier id);
        Task Add(TAggregate aggregate);
        Task Update(TAggregate aggregate);
    }
}