using System.ComponentModel.DataAnnotations;

namespace Shop_API.DTO;

public class LoginDto
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}