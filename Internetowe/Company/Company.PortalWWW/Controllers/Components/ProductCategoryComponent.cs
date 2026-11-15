using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.PortalWWW.Controllers.Components;

public class ProductCategoryComponent(CompanyContext context, ILogger<ProductCategoryComponent> logger) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        try
        {
            logger.LogInformation("Start ProductCategoryComponent");
            return View("ProductCategoryComponent", await context.Category.AsNoTracking().ToListAsync());
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            throw;
        }
    }
}