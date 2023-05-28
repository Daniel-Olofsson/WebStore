using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Contexts;
using WebStore.Models;
using WebStore.Models.ViewModels;
using WebStore.Services;

namespace WebStore.Controllers;
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IdentityContext _identityContext;
    private readonly UserService _userService;
    private readonly UserManager<IdentityUser> _userManager;
    public AdminController(IdentityContext identityContext, UserService userService, UserManager<IdentityUser> userManager)
    {
        _identityContext = identityContext;
        _userService = userService;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Messages()
    {
        var messages = _identityContext.ContactMessages.ToList();
        return View(messages);
    }

    public async Task<IActionResult> Users()
    {
        var users = await _userService.GetAllUsersAsync();
        var userEditVMs = users.Select(userEntity => new UserEditVM
        {
            UserId = userEntity.Id,
            Email = userEntity.Email,
            PhoneNumber = userEntity.PhoneNumber
        }).ToList();

        return View(userEditVMs);
    }

    [HttpPost]
    public IActionResult EditUser(string UserId, string Email)
    {
        var user = _identityContext.Users.FirstOrDefault(u => u.Id == UserId);

        if (user != null)
        {
            user.Email = Email;
            user.UserName = Email;
            user.NormalizedEmail = Email.ToUpper();
            user.NormalizedUserName = Email.ToUpper();
            _identityContext.SaveChanges();

            return RedirectToAction("Users");
        }

        // If user not found, redirect to an error page or handle accordingly
        return RedirectToAction("Error");
    }



    [HttpPost]
    public IActionResult DeleteUser(string id)
    {
        var user = _identityContext.Users.FirstOrDefault(u => u.Id == id);

        if (user != null)
        {
            _identityContext.Users.Remove(user);
            _identityContext.SaveChanges();
        }

        return RedirectToAction("Users");
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UserRegisterVM userViewModel)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return NotFound();
        }

        // Update the user's email
        user.Email = userViewModel.Email;

        // Update the user in the Identity database
        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            // Update additional user profile information if necessary

            // Save changes to the database
            await _identityContext.SaveChangesAsync();

            return RedirectToAction("Profile");
        }

        // If updating the user fails, handle the error accordingly
        ModelState.AddModelError("", "Failed to update user.");

        return View(userViewModel);
    }

}

