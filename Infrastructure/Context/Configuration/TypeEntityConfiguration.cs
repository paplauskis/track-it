using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public abstract class TypeEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
    where TEntity : TypeEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(s => s.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}