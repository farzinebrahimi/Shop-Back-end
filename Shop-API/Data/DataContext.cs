using Microsoft.EntityFrameworkCore;
using Shop_API.Entities.Photos;
using Shop_API.Entities.Users;

namespace Shop_API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Photo> Photos { get; set; }
   
}