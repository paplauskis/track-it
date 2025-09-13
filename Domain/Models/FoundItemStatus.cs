using Domain.Base;

namespace Domain.Models;

public class FoundItemStatus : BaseEntity
{
    public string Status { get; set; }

    public List<FoundItem> Items { get; set; } = [];
}