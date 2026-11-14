using Company.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Company.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.PortalWWW.Controllers
{
    public class HomeController(CompanyContext context, ILogger<HomeController> logger) : Controller
    {
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                id = (await context.Page.FirstOrDefaultAsync())?.IdPage;
                if (id == null)
                    return View(null);
            }
            var item = await context.Page.FindAsync(id);
            return View(item);
        }

        public IActionResult Contact()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
