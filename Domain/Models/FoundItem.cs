using Domain.Base;

namespace Domain.Models;

public class FoundItem : Item
{
    public FoundItemStatus Status { get; set; }
    
    public int StatusId { get; set; }
    
    public string? ImageUrl { get; set; }
}