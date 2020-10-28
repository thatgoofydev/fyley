using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDCore.Infrastructure.DataAccess.EventStore
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(e => e.EventId);
            builder.Property(e => e.EventId)
                .IsRequired();

            builder.Property(e => e.AggregateId)
                .IsRequired();

            builder.Property(e => e.AggregateVersion)
                .IsRequired();

            builder.Property(e => e.EventType)
                .IsRequired();

            builder.Property(e => e.EventJson)
                .IsRequired();

            builder.Property(e => e.Created)
                .IsRequired();
        }
    }
}