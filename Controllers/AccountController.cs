using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Contexts;
using WebStore.Models.ViewModels;
using WebStore.Services;

namespace WebStore.Controllers;

public class AccountController : Controller
{
    private readonly AuthService _authService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityContext _identityContext;
    public AccountController(AuthService authService, UserManager<IdentityUser> userManager, IdentityContext identityContext)
    {
        _authService = authService;
        _userManager = userManager;
        _identityContext = identityContext;
    }
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
    


    
    [HttpPost]
    public async Task<IActionResult> Register(UserRegisterVM vmodel)
    {
        if (ModelState.IsValid)
        {


            if (await _authService.RegisterAsync(vmodel))
            {
                return RedirectToAction("Login");
            }



            ModelState.AddModelError("", "error");



        }
        return View(vmodel);
    }




    [HttpPost]
    public async Task<IActionResult> Login(AccessVM vmodel)
    {
        if (ModelState.IsValid)
        {

            if (await _authService.LoginAsync(vmodel))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "error, invalid inputs");
        }
        return View(vmodel);
    }
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
    //[Authorize]
    //[HttpGet]
    //public async Task<IActionResult> Profile()
    //{
    //    // Get the currently logged in user
    //    var user = await _userManager.GetUserAsync(User);

    //    if (user == null)
    //    {
    //        return NotFound();
    //    }
    //    var userEntity = await _identityContext.UserProfiles.FirstOrDefaultAsync(ue => ue.UserId == user.Id);
    //    if (userEntity == null)
    //    {
    //        return NotFound();
    //    }

    //    // Map the user entity to the view model
    //    var userViewModel = new UserRegisterVM
    //    {
    //        FirstName = userEntity.FirstName,
    //        LastName = userEntity.LastName,
    //        Email = user.Email!,
    //        StreetName = userEntity.StreetName,
    //        PostalCode = userEntity.PostalCode,
    //        City = userEntity.City
    //    };

    //    return View(userViewModel);
    //}
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        // Get the currently logged in user
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return NotFound();
        }
        var userEntity = await _identityContext.UserProfiles.FirstOrDefaultAsync(ue => ue.UserId == user.Id);
        if (userEntity == null)
        {
            return NotFound();
        }

        // Map the user entity to the view model
        var userViewModel = new UserRegisterVM
        {
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            Email = user.Email!,
            StreetName = userEntity.StreetName,
            PostalCode = userEntity.PostalCode,
            City = userEntity.City
        };

        return View(userViewModel);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UpdateProfile(UserRegisterVM userViewModel)
    {
        // Get the currently logged in user
        var user = await _userManager.GetUserAsync(User);
        var userEntity = await _identityContext.UserProfiles.FirstOrDefaultAsync(ue => ue.UserId == user.Id);
        if (user == null)
        {
            return NotFound();
        }

        // Update the user entity with the new values from the view model
        userEntity.FirstName = userViewModel.FirstName;
        userEntity.LastName = userViewModel.LastName;
        userEntity.StreetName = userViewModel.StreetName;
        userEntity.PostalCode = userViewModel.PostalCode;
        userEntity.City = userViewModel.City;

        // Save changes to the database
        await _identityContext.SaveChangesAsync();

        return RedirectToAction("Profile");
    }
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        if(await _authService.LogoutAsync(User))
        {
            return LocalRedirect("/");
        }
        return RedirectToAction("Index");
    }
}
