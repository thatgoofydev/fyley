using System.Data.Common;
using System.Threading.Tasks;
using DDDCore.Application.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DDDCore.Infrastructure.DataAccess
{
    public abstract class ContextBase<TContext> : DbContext, IUnitOfWork
        where TContext : ContextBase<TContext>
    {
        public IEventStore EventStore { get; }

        protected ContextBase(DbContextOptions<TContext> options) : base(options)
        {
        }
        
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