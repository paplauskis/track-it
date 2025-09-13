using Domain.Base;

namespace Domain.Models;

public class FoundItemStatusHistory : TimestampedEntity
{
    public int ItemId { get; set; }
    
    public FoundItem Item { get; set; }

    public int StatusId { get; set; }
    
    public FoundItemStatus Status { get; set; }
}