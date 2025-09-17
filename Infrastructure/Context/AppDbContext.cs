using Domain.Base;
using Domain.Models;
using Infrastructure.Context.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Address>  Addresses { get; set; } = null!;
    public DbSet<User> Users { get; set; }  = null!;
    public DbSet<ItemType> ItemTypes { get; set; }  = null!;
    public DbSet<FoundItemStatus>  FoundItemStatuses { get; set; }  = null!;
    public DbSet<LostItem>  LostItems { get; set; }  = null!;
    public DbSet<FoundItem>  FoundItems { get; set; } = null!;
}