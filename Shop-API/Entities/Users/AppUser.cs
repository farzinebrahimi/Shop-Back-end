namespace Shop_API.Entities.Users;

public class AppUser
{
    public int Id { get; set; }
    public required string PhoneNumber { get; set; } 
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; } 
}