using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Company.PortalWWW.Controllers;

public class NewsController(CompanyContext context, ILogger<NewsController> logger) : Controller
{
    public async Task<IActionResult> Index(int? id)
    {
        ViewBag.ModelPage =
        (
            from page in context.Page
            orderby page.DisplayOrder
            select page
        ).ToList();

        ViewBag.ModelNews =
        (
            from news in context.News
            orderby news.DisplayOrder
            select news
        ).ToList();
        
        var item = await context.News.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }
}
