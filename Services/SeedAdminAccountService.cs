using Microsoft.AspNetCore.Identity;

namespace WebStore.Services;

public class SeedAdminAccountService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedAdminAccountService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedAdminAccount()
    {
        var roleName = "admin";
        var email = "admin@example.com";
        var password = "admin123";

        if (await _roleManager.FindByNameAsync(roleName) == null)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        if (await _userManager.FindByNameAsync(email) == null)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }

    }
}
