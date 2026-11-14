using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.PortalWWW.Controllers;

public class ShopController(CompanyContext context, ILogger<CartController>  logger) : Controller
{
    public async Task<IActionResult> Index(int? id)
    {
        if (id == null)
        {
            var firstCategory = await context.Category.FirstOrDefaultAsync();
            if (firstCategory == null)
            {
                return NotFound();
            }
            id = firstCategory.IdCategory;
        }

        var item = 
            await context.Category
                .Include(cat => cat.Products)
                .AsNoTracking()
            .FirstOrDefaultAsync(category => category.IdCategory == id);
        return View(item);
    }

    public async Task<IActionResult> Details(int? id)
    {
        var item = await context.Product.FirstOrDefaultAsync(a => a.IdProduct == id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
        
    }
}