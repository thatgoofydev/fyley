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

        public DossiersContext(DbContextOptions<DossiersContext> options) : base(options, "Dossiers")
        { }

        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DossierConfiguration());
        }
    }
}