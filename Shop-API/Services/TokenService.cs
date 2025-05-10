using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Shop_API.Entities.Users;
using Shop_API.Interfaces;

namespace Shop_API.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string GenerateToken(AppUser user)
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception("Token key not found");
        if(tokenKey.Length < 64) throw new Exception("Token key is too short");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.PhoneNumber),
        };
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            
            SigningCredentials = creds
        };
        Debug.WriteLine(DateTime.UtcNow.ToString());
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);


    }
}