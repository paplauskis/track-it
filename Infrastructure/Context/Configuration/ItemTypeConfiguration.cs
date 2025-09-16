using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class ItemTypeConfiguration : BaseEntityConfiguration<ItemType>
{
    public override void Configure(EntityTypeBuilder<ItemType> builder)
    {
        base.Configure(builder);

        builder.ToTable("item_type");
        
        builder.Property(i => i.Name)
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnName("name");
    }
}