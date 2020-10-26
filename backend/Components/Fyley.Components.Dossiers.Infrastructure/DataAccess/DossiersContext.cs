using System.Threading.Tasks;
using DDDCore.Infrastructure.DataAccess;
using Fyley.Components.Dossiers.Application.DataAccess;
using Fyley.Components.Dossiers.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Dossiers.Infrastructure.DataAccess
{
    public class DossiersContext : ContextBase<DossiersContext>, IDossiersUnitOfWork
    {
        public DbSet<DossierState> Dossiers { get; [UsedImplicitly] set; }
        
        public DossiersContext(DbContextOptions<DossiersContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DossierConfiguration());
        }
    }
}