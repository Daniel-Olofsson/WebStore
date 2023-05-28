using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Contexts;
using WebStore.Models;

namespace WebStore.Services;

public class UserService
{
    private readonly IdentityContext _identityContext;

    public UserService(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }
    public async Task<UserEntity> GetProfileAsync(string userId)
    {
        var profileEntity = await _identityContext.UserProfiles.Include(x =>
        x.User).FirstOrDefaultAsync(x =>
        x.UserId == userId);
        return profileEntity!;
    }
    public async Task<List<IdentityUser>> GetAllUsersAsync()
    {
        return await _identityContext.Users.ToListAsync();
    }
    public async Task UpdateUserAsync(UserEntity user)
    {
        _identityContext.Entry(user).State = EntityState.Modified;
        await _identityContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(string userId)
    {
        var user = await _identityContext.UserProfiles.FindAsync(userId);
        if (user != null)
        {
            _identityContext.UserProfiles.Remove(user);
            await _identityContext.SaveChangesAsync();
        }
    }
    public async Task<IdentityUser> FindUserByIdAsync(string userId)
    {
        return await _identityContext.Users.FindAsync(userId);
    }

}
