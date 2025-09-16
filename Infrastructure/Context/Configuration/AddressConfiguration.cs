using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class AddressConfiguration : BaseEntityConfiguration<Address>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("address");
        
        builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("country");
        
        builder.Property(x => x.City)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("city");;
        
        builder.Property(x => x.Street)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("street");
        
        builder.Property(x => x.BuildingNumber)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("building_number");
        
        builder.Property(x => x.Latitude)
            .IsRequired()
            .HasColumnName("latitude");
        
        builder.Property(x => x.Longitude)
            .IsRequired()
            .HasColumnName("longitude");
    }
}