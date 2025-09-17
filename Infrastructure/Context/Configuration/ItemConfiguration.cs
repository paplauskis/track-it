using Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class ItemConfiguration : TimestampedEntityConfiguration<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);
        builder.ToTable("item");
        
        builder.HasOne(i => i.Address)
            .WithOne()
            .HasForeignKey<Item>(i => i.AddressId)
            .IsRequired()
            .HasConstraintName("FK_Item_Address");

        builder.HasOne(i => i.Type)
            .WithMany()
            .HasForeignKey(i => i.TypeId)
            .IsRequired()
            .HasConstraintName("FK_Item_Type");

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