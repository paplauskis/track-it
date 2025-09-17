using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class FoundItemConfiguration : IEntityTypeConfiguration<FoundItem>
{
    public void Configure(EntityTypeBuilder<FoundItem> builder)
    {
        builder.ToTable("found_item");
        builder.HasKey(i => i.ItemId);
        
        builder.HasOne(i => i.Item)
            .WithOne()
            .HasForeignKey<FoundItem>(i => i.ItemId)
            .IsRequired()
            .HasConstraintName("FK_FoundItem_Item");
        
        builder.Property(i => i.ItemId).HasColumnName("item_id");

        builder.Property(i => i.StatusId)
            .IsRequired()
            .HasColumnName("status_id");

        builder.Property(i => i.LastStatusUpdateDate)
            .IsRequired()
            .HasColumnName("last_status_update_date");

        builder.Property(i => i.ImageUrl)
            .HasColumnName("image_url");

        builder.HasOne(i => i.Status)
            .WithMany(s => s.Items)
            .HasForeignKey(i => i.StatusId)
            .IsRequired()
            .HasConstraintName("FK_FoundItem_Status");
    }
}