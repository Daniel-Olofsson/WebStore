using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebStore.Contexts;
using WebStore.Models;
using WebStore.Models.ViewModels;

namespace WebStore.Controllers;

[Authorize(Roles = "Admin")]
public class ProductController : Controller
{
    private readonly IdentityContext _context;

    public ProductController(IdentityContext context)
    {
        _context = context;
    }

    // GET: Product
    public async Task<IActionResult> Index()
    {
        return _context.ProductEntity != null ?
                    View(await _context.ProductEntity.ToListAsync()) :
                    Problem("Entity set 'IdentityContext.ProductEntity'  is null.");

    }

    // GET: Product/Details/5
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

    // GET: Product/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Product/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Genre,Price,ImageUrl,CollectionStatus")] ProductEntity productEntity)
    {
        if (ModelState.IsValid)
        {
            _context.Add(productEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(productEntity);
    }

    // GET: Product/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.ProductEntity == null)
        {
            return NotFound();
        }

        var productEntity = await _context.ProductEntity.FindAsync(id);
        if (productEntity == null)
        {
            return NotFound();
        }
        return View(productEntity);
    }

    // POST: Product/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Price,ImageUrl,CollectionStatus")] ProductEntity productEntity)
    {
        if (id != productEntity.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(productEntity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(productEntity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(productEntity);
    }

    // GET: Product/Delete/5
    public async Task<IActionResult> Delete(int? id)
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

    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.ProductEntity == null)
        {
            return Problem("Entity set 'IdentityContext.ProductEntity'  is null.");
        }
        var productEntity = await _context.ProductEntity.FindAsync(id);
        if (productEntity != null)
        {
            _context.ProductEntity.Remove(productEntity);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductEntityExists(int id)
    {
      return (_context.ProductEntity?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
