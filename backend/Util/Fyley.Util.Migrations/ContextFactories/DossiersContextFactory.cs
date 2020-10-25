using Fyley.Components.Dossiers.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fyley.Util.Migrations.ContextFactories
{
    public class DossiersContextFactory : IDesignTimeDbContextFactory<DossiersContext>
    {
        public DossiersContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DossiersContext>();
            builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=dossiers_dev;Trusted_Connection=True;");
            return new DossiersContext(builder.Options);
        }
    }
}