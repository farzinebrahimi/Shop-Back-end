using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Entities.Users;
using Shop_API.Interfaces.Repositories;

namespace Shop_API.Controllers;


[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    [HttpGet] // /api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await userRepository.GetUsersAsync();

        return Ok(users);
    }

    [HttpGet("{username}")] // api/users/{id}
    public async Task<ActionResult<AppUser>> GetUsers(string username)
    {
        var user = await userRepository.GetByUserNameAsync(username);

        if (user == null) return NotFound();

        return user;
    }
}