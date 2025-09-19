using Domain.Base;

namespace Domain.Models;

public class FoundItemStatus : TypeEntity
{
    public List<FoundItem> Items { get; set; } = [];
}