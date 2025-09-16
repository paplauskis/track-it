using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public abstract class TimestampedEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
    where TEntity : TimestampedEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        
        builder.Property(i => i.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
    }
}