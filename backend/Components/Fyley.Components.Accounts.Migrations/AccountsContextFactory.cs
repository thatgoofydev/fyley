using Fyley.Components.Accounts.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fyley.Components.Accounts.Migrations
{
    public class AccountsContextFactory : IDesignTimeDbContextFactory<AccountsContext>
    {
        public AccountsContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AccountsContext>();
            builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=accounts_dev;Trusted_Connection=True;",
                b => b.MigrationsAssembly("Fyley.Components.Accounts.Migrations"));
            return new AccountsContext(builder.Options);
        }
    }
}