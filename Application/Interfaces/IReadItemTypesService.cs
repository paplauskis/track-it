using Domain.Models;

namespace Application.Interfaces;

public interface IReadItemTypesService
{
    Task<IEnumerable<ItemType>> GetAll();
    
    Task<ItemType> GetById(int id);
}