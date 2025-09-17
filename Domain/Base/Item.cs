using Domain.Models;

namespace Domain.Base;

public class Item : TimestampedEntity
{
    public ItemType Type { get; set; }
    
    public int TypeId { get; set; }
    
    // if an item was lost, then address means last seen; otherwise address is for where an item was found
    public Address Address { get; set; }
    
    public int AddressId { get; set; }
    
    public string Description { get; set; }
    
    public string Phone { get; set; }
}