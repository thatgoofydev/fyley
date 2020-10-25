using System.Threading.Tasks;
using Fyley.Components.Dossiers.Application.DataAccess;
using Fyley.Components.Dossiers.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Dossiers.Infrastructure.DataAccess
{
    public class DossiersContext : DbContext, IDossiersUnitOfWork
    {

        public DbSet<DossierState> Dossiers { get; set; }
        
        public DossiersContext(DbContextOptions<DossiersContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DossierConfiguration());
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}