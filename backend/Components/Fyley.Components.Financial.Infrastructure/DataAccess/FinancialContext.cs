using DDDCore.Infrastructure.DataAccess;
using Fyley.Components.Financial.Application;
using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Transactions;
using Fyley.Components.Financial.Infrastructure.DataAccess.Accounts.Configurations;
using Fyley.Components.Financial.Infrastructure.DataAccess.Transactions.Configuration;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Financial.Infrastructure.DataAccess
{
    public class FinancialContext : ContextBase<FinancialContext>, IFinancialUnitOfWork
    {
        public DbSet<AccountState> Accounts { get; [UsedImplicitly] set; }
        public DbSet<TransactionState> Transactions { get; [UsedImplicitly] set; }
        
        public FinancialContext(DbContextOptions<FinancialContext> options) : base(options, "Financial")
        {
        }

        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}