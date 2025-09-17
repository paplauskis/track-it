using Domain.Base;

namespace Domain.Models;

public class LostItem
{
    public Item Item { get; set; }
    
    public int ItemId { get; set; }
    
    public DateTime LostDate { get; set; }
    
    public decimal? RewardAmount { get; set; }
}