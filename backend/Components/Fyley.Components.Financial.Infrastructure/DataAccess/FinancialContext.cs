using DDDCore.Infrastructure.DataAccess;
using Fyley.Components.Financial.Application;
using Fyley.Components.Financial.Domain.Transactions;
using Fyley.Components.Financial.Infrastructure.DataAccess.Transactions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Financial.Infrastructure.DataAccess
{
    public class FinancialContext : ContextBase<FinancialContext>, IFinancialUnitOfWork
    {
        public DbSet<TransactionState> Transactions { get; set; }
        
        public FinancialContext(DbContextOptions<FinancialContext> options) : base(options, "Financial")
        {
        }

        public override void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        }
    }
}