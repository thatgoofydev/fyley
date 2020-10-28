using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDCore.Infrastructure.Extensions.DataAccess
{
    public static class EntityTypeBuilderExtensions
    {

        public static void ConfigureBase<TEntity>(this EntityTypeBuilder<TEntity> builder, string table, string idKey)
            where TEntity : class
        {
            builder.ToTable(table);
            
            builder.Property<Guid>(idKey);
            builder.HasKey(idKey);
            
            builder.Property<long>("Version");
        }
        
    }
}