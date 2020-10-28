using System.Data.Common;
using System.Threading.Tasks;
using DDDCore.Application.DataAccess;
using DDDCore.Infrastructure.DataAccess.EventStore;
using Microsoft.EntityFrameworkCore;

namespace DDDCore.Infrastructure.DataAccess
{
    public abstract class ContextBase<TContext> : DbContext, IUnitOfWork
        where TContext : ContextBase<TContext>
    {
        private readonly string _defaultSchema;
        public IEventStore EventStore { get; }

        public DbSet<Event> Events { get; set; }
        
        protected ContextBase(DbContextOptions<TContext> options, string defaultSchema) : base(options)
        {
            _defaultSchema = defaultSchema;
            EventStore = new EventStoreBase(Events);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_defaultSchema);
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            
            Configure(modelBuilder);
        }

        public abstract void Configure(ModelBuilder modelBuilder);

        public async Task Commit()
        {
            await SaveChangesAsync();
        }

        public DbConnection GetConnection()
        {
            return Database.GetDbConnection();
        }
    }
}