using Shop_API.Entities.Users;

namespace Shop_API.Interfaces;

public interface ITokenService
{
    string GenerateToken(AppUser user);
}