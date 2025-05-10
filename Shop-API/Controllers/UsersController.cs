using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_API.Data;
using Shop_API.DTO;
using Shop_API.Entities.Users;

namespace Shop_API.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class UsersController(DataContext context) : BaseApiController
{
    
    [HttpPost("register")] // /api/account/register
    public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto )
    {
        if(await UserExists(registerDto.PhoneNumber)) return BadRequest("User already exists");
        
        using var hmac = new HMACSHA512();
       
        var user =new AppUser
        {
            PhoneNumber = registerDto.PhoneNumber.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    private async Task<bool> UserExists(string phoneNumber)
    {
        return await context.Users.AnyAsync(x => x.PhoneNumber.ToLower() == phoneNumber.ToLower());
    }
    
    [HttpGet] // /api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }
    
    [HttpGet("{id:int}")] // api/users/{id}
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();

        return user;

    }
    
    
}