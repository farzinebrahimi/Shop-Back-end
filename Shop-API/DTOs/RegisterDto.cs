using System.ComponentModel.DataAnnotations;

namespace Shop_API.DTO;

public class RegisterDto
{
    [Required]
    public required string PhoneNumber { get; set; }
    [Required]
    public required string Password { get; set; }
}