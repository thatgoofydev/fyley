using DDDCore.Infrastructure.DataAccess;
using Fyley.Services.Account.Domain;
using Fyley.Services.Account.Infrastructure.EfConfigurations;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Services.Account.Infrastructure
{
    public class AccountDbContext : ContextBase<AccountDbContext>
    {

        public DbSet<AccountState> Accounts { get; [UsedImplicitly] set; }
        
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options, "Accounts")
        {
        }

        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}