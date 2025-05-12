using System.ComponentModel.DataAnnotations;

namespace Shop_API.DTO;

public class RegisterDto
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Password { get; set; }
}