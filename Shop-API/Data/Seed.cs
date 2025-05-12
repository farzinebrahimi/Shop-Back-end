using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Shop_API.Entities.Users;

namespace Shop_API.Data;

public class Seed
{
    public static async Task SeedUsers(DataContext context)
    {
        if (await context.Users.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

        if (users == null) return;

        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();
            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
            user.PasswordSalt = hmac.Key;
            
            user.Created = DateTime.SpecifyKind(user.Created, DateTimeKind.Utc);
            user.LastActive = DateTime.SpecifyKind(user.LastActive, DateTimeKind.Utc);

            context.Users.Add(user);
        }

        await context.SaveChangesAsync();
    }
}