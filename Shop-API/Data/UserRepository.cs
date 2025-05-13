using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shop_API.DTOs;
using Shop_API.Entities.Users;
using Shop_API.Interfaces.Repositories;

namespace Shop_API.Data;

public class UserRepository(DataContext context, IMapper mapper): IUserRepository
{
    public void Update(AppUser user)
    {
        context.Entry(user).State = EntityState.Modified;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
    

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await context.Users
            .Include(x => x.Photos)
            .ToListAsync();
    }

    public async Task<AppUser?> GetByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<AppUser?> GetByUserNameAsync(string userName)
    {
        return await context.Users
            .Include(x => x.Photos)
            .SingleOrDefaultAsync(x => x.UserName == userName);
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await context.Users
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<MemberDto?> GetMemberAsync(string userName)
    {
        return await context.Users
            .Where(x => x.UserName == userName)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();

    }
}