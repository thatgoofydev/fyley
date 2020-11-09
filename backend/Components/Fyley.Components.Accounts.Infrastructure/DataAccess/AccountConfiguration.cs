using DDDCore.Infrastructure.Extensions.DataAccess;
using Fyley.Components.Accounts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fyley.Components.Accounts.Infrastructure.DataAccess
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountState>
    {
        public void Configure(EntityTypeBuilder<AccountState> builder)
        {
            builder.ConfigureBase("Accounts", "AccountId");
            
            builder.Property(e => e.Name)
                .HasConversion(valueObj => valueObj.Value, value => new AccountName(value));
            
            builder.Property(e => e.Description)
                .HasConversion(valueObj => valueObj.Value, value => new AccountDescription(value));

            builder.OwnsOne(e => e.AccountNumber, rb =>
            {
                rb.Property(e => e.Type)
                    .HasConversion(valueObj => valueObj.Value, value => AccountNumberType.FromValue(value));
                
                rb.Property(e => e.Value);
            });
            
            builder.Property(e => e.Balance)
                .HasConversion(valueObj => valueObj.Amount, value => new Money(value));
        }
    }
}