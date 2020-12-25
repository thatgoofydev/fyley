using DDDCore.Infrastructure.Extensions.DataAccess;
using Fyley.Services.Account.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fyley.Services.Account.Infrastructure.EfConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountState>
    {
        public void Configure(EntityTypeBuilder<AccountState> builder)
        {
            builder.ConfigureBase("Accounts", nameof(AccountId));
            
            builder.Property(e => e.Name)
                .HasConversion(valueObj => valueObj.Value, value => new AccountName(value));
            
            builder.Property(e => e.Description)
                .HasConversion(valueObj => valueObj.Value, value => new AccountDescription(value));
            
            builder.OwnsOne(e => e.AccountNumber, accountNumberBuilder =>
            {
                accountNumberBuilder.Property(e => e.Type)
                    .HasConversion(valueObj => valueObj.Value, value => AccountNumberType.FromValue(value));

                accountNumberBuilder.Property(e => e.Value);
            });
        }
    }
}