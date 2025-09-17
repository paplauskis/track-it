using Domain.Base;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class LostItemConfiguration : IEntityTypeConfiguration<LostItem>
{
    public void Configure(EntityTypeBuilder<LostItem> builder)
    {
        builder.ToTable("lost_item");
        builder.HasKey(i => i.ItemId);
        
        builder.HasOne(i => i.Item)
            .WithOne()
            .HasForeignKey<LostItem>(i => i.ItemId)
            .IsRequired()
            .HasConstraintName("FK_LostItem_Item");
        
        builder.Property(i => i.ItemId).HasColumnName("item_id");
        
        builder.Property(i => i.LostDate)
            .IsRequired()
            .HasColumnName("lost_date");

        builder.Property(i => i.RewardAmount)
            .IsRequired()
            .HasColumnName("reward_amount");
    }
}