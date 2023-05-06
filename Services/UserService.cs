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
        var profileEntity = await _identityContext.UserProfiles.Include(x=> 
        x.User).FirstOrDefaultAsync(x=>
        x.UserId == userId);
        return profileEntity!;
    }
}
