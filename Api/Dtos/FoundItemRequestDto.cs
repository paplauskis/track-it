namespace Api.Dtos;

public class FoundItemRequestDto
{
    public ItemDto? Item { get; set; }
    public string? Status { get; set; }
    public string? ImageUrl { get; set; }
    public PostalAddressDto? PostalAddress { get; set; }
    public GeoAddressDto? GeoAddress { get; set; }
}