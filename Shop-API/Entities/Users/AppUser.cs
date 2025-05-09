namespace Shop_API.Entities.Users;

public class AppUser
{
    public int Id { get; set; }
    public required string PhoneNumber { get; set; } 
    public required string Password { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; } 
}