using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebStore.Contexts;
using WebStore.Models;
using WebStore.Models.ViewModels;
using WebStore.Services;

namespace WebStore.Controllers;

public class HomeController : Controller

{
    private readonly IdentityContext _context;
    private readonly ProductService _productService;
    public HomeController(IdentityContext context, ProductService productService)
    {
        _context = context;
        _productService = productService;
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
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.ProductEntity == null)
        {
            return NotFound();
        }

        var productEntity = await _context.ProductEntity
            .FirstOrDefaultAsync(m => m.Id == id);
        if (productEntity == null)
        {
            return NotFound();
        }

        return View(productEntity);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult AllTopCollectionProducts()
    {
        var upToSaleProducts = _productService.GetProductsByCollectionStatus("TopCollection");
        return View(upToSaleProducts);
    }
    public IActionResult AllSaleCollectionProducts()
    {
        var upToSaleProducts = _productService.GetProductsByCollectionStatus("UpToSale");
        return View(upToSaleProducts);
    }

}