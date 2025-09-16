using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public abstract class ItemConfiguration<TEntity> : TimestampedEntityConfiguration<TEntity>
    where TEntity : Item
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder.HasOne(i => i.Address)
            .WithOne()
            .HasForeignKey<TEntity>(i => i.AddressId)
            .IsRequired();

        builder.HasOne(i => i.Type)
            .WithMany()
            .HasForeignKey(i => i.TypeId)
            .IsRequired();
        
        builder.Property(i => i.TypeId)
            .IsRequired()
            .HasColumnName("type_id");
        
        builder.Property(i => i.AddressId)
            .IsRequired()
            .HasColumnName("address_id");
        
        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("description");

        builder.Property(i => i.Phone)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("phone");
    }
}