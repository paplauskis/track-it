using Domain.Base;

namespace Domain.Models;

public class ItemType : BaseEntity
{
    public string Name { get; set; }
    
    public List<Item> Items { get; set; } = [];
}