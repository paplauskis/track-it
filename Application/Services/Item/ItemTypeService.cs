using Application.Interfaces;
using Domain.Exceptions;
using Domain.Interfaces.Repositories.Generic;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services.Item;

public class ItemTypeService : IReadItemTypesService
{
    private readonly ILogger<ItemTypeService> _logger;
    private readonly IReadRepository<ItemType> _itemTypeRepository;

    public ItemTypeService(
        IReadRepository<ItemType> itemTypeRepository,
        ILogger<ItemTypeService> logger)
    {
        _itemTypeRepository = itemTypeRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<ItemType>> GetAll()
    {
        _logger.LogInformation("Retrieving all item types.");
        var itemTypes = await _itemTypeRepository.GetAllAsync();

        if (itemTypes.Any())
        {
            _logger.LogInformation("Retrieved {Count} item types.", itemTypes.Count);
            return itemTypes;
        }

        _logger.LogWarning("No item types found in database.");
        throw new NoEntitiesFoundException();
    }
    
    public async Task<ItemType> GetById(int id)
    {
        _logger.LogInformation("Fetching item type with ID {Id}.", id);
        var itemType = await _itemTypeRepository.GetByIdAsync(id);

        if (itemType != null)
        {
            _logger.LogInformation("Item type with ID {Id} retrieved successfully.", id);
            return itemType;
        }

        _logger.LogWarning("Item type with ID {Id} not found in database.", id);
        throw new EntityNotFoundException($"Item type with ID {id}  not found.");
    }
}