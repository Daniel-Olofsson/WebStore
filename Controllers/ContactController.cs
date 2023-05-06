using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Contexts;
using WebStore.Models;
using WebStore.Models.ViewModels;

namespace WebStore.Controllers;

public class ContactController : Controller
{
    private readonly IdentityContext _identityContext;
    public ContactController(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(ContactVM model)
    {
        if (ModelState.IsValid)
        {
            var message = new ContactEntity
            {
                Name = model.Name,
                Email = model.Email,
                Subject = model.Subject,
                Message = model.Message
            };

            _identityContext.ContactMessages.Add(message);
            await _identityContext.SaveChangesAsync();

            // Redirect to the confirmation page
            return RedirectToAction("MessageSent");
        }

        // If we got this far, something failed, redisplay form
        return View(model);
    }
    public IActionResult MessageSent()
    {
        return View();
    }
}
