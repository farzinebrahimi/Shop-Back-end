using Shop_API.DTOs;
using Shop_API.Entities.Users;

namespace Shop_API.Interfaces.Repositories;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetByIdAsync(int id);
    Task<AppUser?> GetByUserNameAsync(string userName);
    Task<IEnumerable<MemberDto>> GetMembersAsync();
    Task<MemberDto?> GetMemberAsync(string userName);
}