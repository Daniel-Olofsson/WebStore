using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebStore.Contexts;
using WebStore.Models;
using WebStore.Models.ViewModels;

namespace WebStore.Services;

public class AuthService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityContext _identityContext;
    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
    }
    //public async Task<bool> RegisterAsync(UserRegisterVM vm)
    //{
    //    try
    //    {
    //        //user
    //        IdentityUser identityUser = vm;
    //        await _userManager.CreateAsync(identityUser, vm.Password);
    //        //profile
    //        UserEntity _user = vm;
    //        _user.UserId = identityUser.Id;

    //        _identityContext.UserProfiles.Add(_user);
    //        await _identityContext.SaveChangesAsync();
    //        return true;
    //    }
    //    catch
    //    {
    //        return false;

    //    }
    //}
    public async Task<bool> RegisterAsync(UserRegisterVM vm)
    {
        try
        {
            // Create the IdentityUser
            IdentityUser identityUser = new IdentityUser
            {
                UserName = vm.Email,
                Email = vm.Email
            };

            // Create the user in the Identity database
            var result = await _userManager.CreateAsync(identityUser, vm.Password);
            if (!result.Succeeded)
            {
                // Failed to create the user
                return false;
            }

            // Create the UserEntity
            UserEntity userEntity = new UserEntity
            {
                UserId = identityUser.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                StreetName = vm.StreetName,
                PostalCode = vm.PostalCode,
                City = vm.City
            };

            // Add the UserEntity to the IdentityContext and save changes
            _identityContext.UserProfiles.Add(userEntity);
            await _identityContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> LoginAsync(AccessVM accessVM)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(accessVM.Email, accessVM.Password, accessVM.RememberMe, false);
            
            return result.Succeeded;
        }
        catch
        {
            return false;
        }
    }
    public async Task<bool> LogoutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);

    }
}
