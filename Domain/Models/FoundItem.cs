using Domain.Base;

namespace Domain.Models;

public class FoundItem : Item
{
    public FoundItemStatus Status { get; set; }
    
    public int StatusId { get; set; }
    
    public DateTime LastStatusUpdateDate { get; set; } = DateTime.UtcNow;
    
    public string? ImageUrl { get; set; }
}