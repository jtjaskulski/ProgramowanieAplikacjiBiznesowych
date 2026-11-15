using Company.Data.Data;
using Company.Data.Models.Shop;
using Company.PortalWWW.Models.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Company.PortalWWW.Controllers;

public class OrderController(CompanyContext context, ILogger<OrderController>  logger) : Controller
{
    public async Task<IActionResult> Data()
    { 
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Data([Bind("Login,FirstName,LastName,Street,City,Voivodeship,ZipCode,Country,PhoneNumber,Email,Total")] Order order) 
    {
        if (!ModelState.IsValid)
        {
            return View(order);
        }
        var result = await new CartB(context, HttpContext, logger)
                .ConvertToOrder(order, HttpContext);

        return RedirectToAction(nameof(Summary), new { id = result.IdOrder });
    }

    public async Task<IActionResult> Summary(int? id)
    {
        var order = await context.Order.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

}