using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fyley.Services.Account.Infrastructure.Migrations
{
    public class AccountContextFactory : IDesignTimeDbContextFactory<AccountDbContext>
    {
        public AccountDbContext CreateDbContext(string[] args)
        {
            var connectionString = args.Length > 0 ? args[0]
                : "Server=.\\SQLEXPRESS;Database=fyley_dev;Trusted_Connection=True;";
            
            var builder = new DbContextOptionsBuilder<AccountDbContext>();
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(GetType().Assembly.FullName));
            return new AccountDbContext(builder.Options);
        }
    }
}