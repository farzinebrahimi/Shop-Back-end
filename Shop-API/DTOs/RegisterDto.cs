using System.ComponentModel.DataAnnotations;

namespace Shop_API.DTOs;

public class RegisterDto
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Password { get; set; }
}