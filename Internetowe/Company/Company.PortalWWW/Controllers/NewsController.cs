using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Company.PortalWWW.Controllers;

public class NewsController(CompanyContext context, ILogger<NewsController> logger) : Controller
{
    public async Task<IActionResult> Index(int? id)
    {
        var item = await context.News.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }
}
