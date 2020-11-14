using DDDCore.Infrastructure.Extensions.DataAccess;
using Fyley.Components.Financial.Domain.Shared;
using Fyley.Components.Financial.Domain.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fyley.Components.Financial.Infrastructure.DataAccess.Transactions.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionState>
    {
        public void Configure(EntityTypeBuilder<TransactionState> builder)
        {
            builder.ConfigureBase("Transactions", "TransactionId");

            builder.OwnsOne(e => e.Payor, rb =>
            {
                rb.Property(e => e.AccountReference)
                    .HasConversion(valueObj => valueObj.ToString(), value => new AccountReference(value));

                rb.OwnsOne(e => e.TransactionAccount, tarb =>
                {
                    tarb.Property(e => e.Name)
                        .HasConversion(valueObj => valueObj.Value, value => new AccountName(value));

                    tarb.OwnsOne(e => e.Number, anrb =>
                    {
                        anrb.Property(e => e.Type)
                            .HasConversion(valueObj => valueObj.Value, value => AccountNumberType.FromValue(value));

                        anrb.Property(e => e.Value);
                    });
                });
            });
            
            builder.OwnsOne(e => e.Payee, rb =>
            {
                rb.Property(e => e.AccountReference)
                    .HasConversion(valueObj => valueObj.ToString(), value => new AccountReference(value));

                rb.OwnsOne(e => e.TransactionAccount, tarb =>
                {
                    tarb.Property(e => e.Name)
                        .HasConversion(valueObj => valueObj.Value, value => new AccountName(value));

                    tarb.OwnsOne(e => e.Number, anrb =>
                    {
                        anrb.Property(e => e.Type)
                            .HasConversion(valueObj => valueObj.Value, value => AccountNumberType.FromValue(value));

                        anrb.Property(e => e.Value);
                    });
                });
            });
            
            builder.Property(e => e.Amount)
                .HasConversion(valueObj => valueObj.Amount, value => new Money(value));

            builder.Property(e => e.OptionalReference)
                .HasConversion(valueObj => valueObj.Value, value => new OptionalReference(value));

            builder.Property(e => e.OccuredOn)
                .HasConversion(valueObj => valueObj.Value, value => new TransactionDateTime(value));
            
            builder.Property(e => e.LoggedOn)
                .HasConversion(valueObj => valueObj.Value, value => new TransactionDateTime(value));
        }
    }
}