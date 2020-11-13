using Fyley.Components.Financial.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fyley.Components.Financial.Migrations
{
    public class FinancialContextFactory : IDesignTimeDbContextFactory<FinancialContext>
    {
        public FinancialContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FinancialContext>();
            builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=financial_dev;Trusted_Connection=True;",
                b => b.MigrationsAssembly("Fyley.Components.Financial.Migrations"));
            return new FinancialContext(builder.Options);
        }
    }
}