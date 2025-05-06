using Microsoft.AspNetCore.Mvc;
using Shop_API.Data;
using Shop_API.Entities.Users;

namespace Shop_API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = context.Users.ToList();

        return users;
    }
    
    [HttpGet("{id:int}")] // api/users/{id}
    public ActionResult<AppUser> GetUsers(int id)
    {
        var user = context.Users.Find(id);

        if (user == null) return NotFound();

        return user;

    }
}