using Domain.Base;

namespace Domain.Models;

//Admin
public class User : TimestampedEntity
{
    public required string Username { get; set; }
    
    public required string Email { get; set; }
    public required string Password { get; set; }
}