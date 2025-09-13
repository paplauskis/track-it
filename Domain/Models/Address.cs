using Domain.Base;

namespace Domain.Models;

public class Address : BaseEntity
{
    public string Country { get; set; }
    
    public string City { get; set; }
    
    public string Street { get; set; }
    
    public string BuildingNumber { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
}