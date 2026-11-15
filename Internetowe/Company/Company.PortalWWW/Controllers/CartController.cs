using Company.Data.Data;
using Company.PortalWWW.Models.BusinessLogic;
using Company.PortalWWW.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Company.PortalWWW.Controllers;

public class CartController(CompanyContext context, ILogger<CartController> logger) : Controller
{
    public async Task<IActionResult> Index()
    {
        var cartB = new CartB(context, HttpContext, logger);
        var dataForCart = new CartViewModel
        {
            CartItems = await cartB.GetCartItems(),
            Total = await cartB.GetTotal()
        };
        return View(dataForCart);
    }

    public async Task<IActionResult> AddToCart(int id)
    {
        var cartB = new CartB(context, HttpContext, logger);
        return await cartB.AddToCart(id) ? RedirectToAction(nameof(Index)) : NotFound();
    }

    public async Task<IActionResult> DeleteCartItem(int id)
    {
        var cartB = new CartB(context, HttpContext, logger);
        return await cartB.DeleteItemFromCart(id) ? RedirectToAction(nameof(Index)) : NotFound();
    }
}