using DDDCore.Infrastructure.DataAccess;
using Fyley.Components.Accounts.Application.DataAccess;
using Fyley.Components.Accounts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Accounts.Infrastructure.DataAccess
{
    public class AccountsContext : ContextBase<AccountsContext>, IAccountsUnitOfWork
    {
        public DbSet<AccountState> Accounts { get; set; }
        
        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options, "Accounts")
        { }

        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}