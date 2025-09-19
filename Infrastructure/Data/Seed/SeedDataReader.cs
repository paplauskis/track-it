using System.Text.Json;
using Common.Helpers;
using Domain.Base;
using Domain.Interfaces.Data;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Seed;

public class SeedDataReader : ITypeEntityDataReader
{
    private readonly string _filePath;
    
    public SeedDataReader(IConfiguration configuration)
    {
        _filePath = configuration["SeedData"] 
                    ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    public IReadOnlyCollection<T> Read<T>() where T : TypeEntity, new()
    {
        var json = File.ReadAllText(PathHelpers.GetSolutionRoot() + _filePath);
        
        return ParseJsonToType<T>(json);
    }
    
    public async Task<IReadOnlyCollection<T>> ReadAsync<T>()
        where T : TypeEntity, new()
    {
        var json = await File.ReadAllTextAsync(PathHelpers.GetSolutionRoot() + _filePath);

        return ParseJsonToType<T>(json);
    }

    private IReadOnlyCollection<T> ParseJsonToType<T>(string json) where T : TypeEntity, new()
    {
        using var document = JsonDocument.Parse(json);
        var root = document.RootElement;
        
        if (root.TryGetProperty(typeof(T).Name, out var section))
        {
            return section.EnumerateArray()
                .Select(x => x.Deserialize<T>())
                .ToList()!;
        }

        return [];
    }
}