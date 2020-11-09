using System;
using System.Threading.Tasks;
using DDDCore.Application.DataAccess;
using DDDCore.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DDDCore.Infrastructure.DataAccess
{
    public abstract class RepositoryBase<TAggregate, TIdentifier, TState> : IRepository<TAggregate, TIdentifier, TState>
        where TAggregate : AggregateBase<TIdentifier, TState>
        where TIdentifier : Identifier
        where TState : class, IAggregateState
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbContext _context;
        protected readonly DbSet<TState> Repository;
        private readonly string _idColumn;

        protected RepositoryBase(IUnitOfWork unitOfWork, DbSet<TState> repository, string idColumn)
        {
            _unitOfWork = unitOfWork;
            _context = unitOfWork as DbContext;
            Repository = repository;
            _idColumn = idColumn;
        }

        protected abstract Task<TState> FetchState(TIdentifier id);
        
        public async Task<TAggregate> FetchAsync(TIdentifier id)
        {
            var state = await FetchState(id);
            var version = (long) _context.Entry(state).Property("Version").CurrentValue;
            return (TAggregate) Activator.CreateInstance(typeof(TAggregate), id, state, version);
        }

        public async Task AddAsync(TAggregate aggregate)
        {
            await _unitOfWork.EventStore.StoreEventsAsync(aggregate.Id, aggregate.Version, aggregate.FlushUncommitedEvents());
            SetShadowProperties(aggregate);
            await Repository.AddAsync(aggregate.State);
        }

        public async Task Update(TAggregate aggregate)
        {
            await _unitOfWork.EventStore.StoreEventsAsync(aggregate.Id, aggregate.Version, aggregate.FlushUncommitedEvents());
            SetShadowProperties(aggregate);
            Repository.Update(aggregate.State);
        }

        private void SetShadowProperties(TAggregate aggregate)
        {
            _context.Entry(aggregate.State).Property(_idColumn).CurrentValue = aggregate.Id.Value;
            _context.Entry(aggregate.State).Property("Version").CurrentValue = aggregate.Version;
        }
    }
}