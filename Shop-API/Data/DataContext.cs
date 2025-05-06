using Microsoft.EntityFrameworkCore;
using Shop_API.Entities.Users;

namespace Shop_API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    /*
     * this is name on table
     */
    public DbSet<AppUser> Users { get; set; }
}