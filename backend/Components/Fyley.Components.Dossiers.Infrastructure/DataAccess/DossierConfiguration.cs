using DDDCore.Infrastructure.Extensions.DataAccess;
using Fyley.Components.Dossiers.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fyley.Components.Dossiers.Infrastructure.DataAccess
{
    public class DossierConfiguration : IEntityTypeConfiguration<DossierState>
    {
        public void Configure(EntityTypeBuilder<DossierState> builder)
        {
            builder.ConfigureBase("Dossiers", "DossierId");

            builder.Property(e => e.Name)
                .HasConversion(valueObj => valueObj.Value, stringVal => new DossierName(stringVal));
        }
    }
}