using Domain.Base;

namespace Domain.Models;

public class FoundItem
{
    public Item Item { get; set; }
    
    public int ItemId { get; set; }
    
    public FoundItemStatus Status { get; set; }
    
    public int StatusId { get; set; }
    
    public DateTime LastStatusUpdateDate { get; set; } = DateTime.UtcNow;
    
    public string? ImageUrl { get; set; }
}