using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Contexts;

namespace WebStore.Controllers;

public class AdminController : Controller
{
    private readonly IdentityContext _identityContext;
    public AdminController(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }
    [Authorize(Roles = "Admin")]
    public IActionResult Index()
    {
        return View();
    }
    [Authorize(Roles = "Admin")]
    public IActionResult Messages()
    {
        var messages = _identityContext.ContactMessages.ToList();
        return View(messages);
    }
}
