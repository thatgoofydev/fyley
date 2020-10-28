using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fyley.Components.Dossiers.Infrastructure.DataAccess
{
    [UsedImplicitly]
    public class DossiersContextDesignTimeFactory : IDesignTimeDbContextFactory<DossiersContext>
    {
        public DossiersContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DossiersContext>();
            builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=dossiers_dev;Trusted_Connection=True;");
            return new DossiersContext(builder.Options);
        }
    }
}