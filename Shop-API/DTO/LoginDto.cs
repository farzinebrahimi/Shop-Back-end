using System.ComponentModel.DataAnnotations;

namespace Shop_API.DTO;

public class LoginDto
{
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
}