using Domain.Base;

namespace Domain.Models;

public class Address : BaseEntity
{
    public PostalAddress Postal { get; set; }
    
    public GeoAddress Geo { get; set; }
}