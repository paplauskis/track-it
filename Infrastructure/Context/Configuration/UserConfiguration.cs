using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configuration;

public class UserConfiguration : TimestampedEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("user");
        
        builder.HasIndex(i => i.Email).IsUnique();
        
        builder.Property(i => i.Username)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("username");
        
        builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("email");
        
        builder.Property(i => i.Password)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("password");
    }
}