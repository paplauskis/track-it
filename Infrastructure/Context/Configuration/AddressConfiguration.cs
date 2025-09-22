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
        
        builder.OwnsOne(a => a.Postal, postal =>
        {
            postal.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("country");
        
            postal.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("city");
        
            postal.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("street");
        
            postal.Property(x => x.BuildingNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("building_number");
        });

        builder.OwnsOne(a => a.Geo, geo =>
        {
            geo.Property(x => x.Latitude)
                .IsRequired()
                .HasColumnName("latitude");
        
            geo.Property(x => x.Longitude)
                .IsRequired()
                .HasColumnName("longitude");
        });
    }
}