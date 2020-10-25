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

        protected readonly DbSet<TState> Repository;
        
        private readonly DbContext _context;
        private readonly string _idColumn;

        protected RepositoryBase(DbContext context, DbSet<TState> repository, string idColumn)
        {
            _context = context;
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

        public void Add(TAggregate aggregate)
        {
            SetShadowProperties(aggregate);
            Repository.Add(aggregate.State);
        }

        public void Update(TAggregate aggregate)
        {
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