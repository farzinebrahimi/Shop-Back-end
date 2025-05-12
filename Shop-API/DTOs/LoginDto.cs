namespace Shop_API.DTOs;

public class LoginDto
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}