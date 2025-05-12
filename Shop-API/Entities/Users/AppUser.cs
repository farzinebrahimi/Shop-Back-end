using Shop_API.Entities.Photos;
using Shop_API.Extensions;

namespace Shop_API.Entities.Users;

public class AppUser
{
    public int Id { get; set; }
    //public required string PhoneNumber { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public required string KnownAs { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastActive { get; set; }
    public required string Gender { get; set; }
    public string? Interduction { get; set; }
    public string? Intrests { get; set; }
    public string? LookingFor { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public List<Photo> Photos { get; set; } = [];

    public int GetAge()
    {
        return DateOfBirth.CalculateAge()
            ;
    }
}

