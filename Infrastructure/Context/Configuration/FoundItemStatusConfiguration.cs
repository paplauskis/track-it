using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class FoundItemStatusConfiguration : BaseEntityConfiguration<FoundItemStatus>
{
    public override void Configure(EntityTypeBuilder<FoundItemStatus> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("found_item_status");

        builder.Property(i => i.Name).HasColumnName("name");
    }
}