using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class FoundItemConfiguration : ItemConfiguration<FoundItem>
{
    public override void Configure(EntityTypeBuilder<FoundItem> builder)
    {
        base.Configure(builder);

        builder.ToTable("found_item");
        
        builder.HasOne(i => i.Status)
            .WithMany(s => s.Items)
            .HasForeignKey(i => i.StatusId)
            .IsRequired();
        
        builder.Property(x => x.StatusId)
            .IsRequired()
            .HasColumnName("status_id");

        builder.Property(i => i.LastStatusUpdateDate)
            .IsRequired()
            .HasColumnName("last_status_update_date");
        
        builder.Property(i => i.ImageUrl).HasColumnName("image_url");
    }
}