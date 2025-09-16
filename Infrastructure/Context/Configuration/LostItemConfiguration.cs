using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class LostItemConfiguration : ItemConfiguration<LostItem>
{
    public override void Configure(EntityTypeBuilder<LostItem> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("lost_item");

        builder.Property(i => i.RewardAmount)
            .IsRequired()
            .HasColumnName("reward_amount");
    }
}