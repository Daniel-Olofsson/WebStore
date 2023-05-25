using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebStore.Contexts;
using WebStore.Models;
using WebStore.Models.ViewModels;

namespace WebStore.Controllers;

public class HomeController : Controller

{
    private readonly IdentityContext _context;

    public HomeController(IdentityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var products = await _context.ProductEntity.ToListAsync();
        var model = new ProductViewModel
        {
            Products = products
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}