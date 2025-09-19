using Domain.Models;
using Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
    {
        _configuration = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var seedDataWriter = new SeedDataWriter(_configuration);
        
        optionsBuilder.UseSeeding((context, _) =>
        {
            seedDataWriter.SeedData(context);
        })
        .UseAsyncSeeding(async (context, _, _) =>
        {
            await seedDataWriter.SeedDataAsync(context);
        });
    }

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