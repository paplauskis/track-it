using Domain.Base;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Seed;

public class SeedDataWriter
{
    private readonly IConfiguration _configuration;

    public SeedDataWriter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SeedData(DbContext context)
    {
        var seedDataReader = new SeedDataReader(_configuration);
        
        SeedEntity(context, seedDataReader.Read<ItemType>());
        SeedEntity(context, seedDataReader.Read<FoundItemStatus>());
    }
    
    public async Task SeedDataAsync(DbContext context)
    {
        var seedDataReader = new SeedDataReader(_configuration);
        
        await SeedEntityAsync(context, await seedDataReader.ReadAsync<ItemType>());
        await SeedEntityAsync(context, await seedDataReader.ReadAsync<FoundItemStatus>());
    }

    private static void SeedEntity<T>(DbContext context, IReadOnlyCollection<T> data) where T : class
    {
        if (!context.Set<T>().Any())
        {
            context.Set<T>().AddRange(data);
            context.SaveChanges();
        }
    }
    
    private static async Task SeedEntityAsync<T>(DbContext context, IReadOnlyCollection<T> data)
        where T : class
    {
        if (!context.Set<T>().Any())
        {
            await context.Set<T>().AddRangeAsync(data);
            await context.SaveChangesAsync();
        }
    }
}