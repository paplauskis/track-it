using Domain.Base;

namespace Domain.Models;

public class LostItem : Item
{
    public decimal? RewardAmount { get; set; }
}