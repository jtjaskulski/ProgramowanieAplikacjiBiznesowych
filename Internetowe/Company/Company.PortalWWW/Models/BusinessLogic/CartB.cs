using Company.Data.Data;
using Company.Data.Models.Shop;
using Company.PortalWWW.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Company.PortalWWW.Models.BusinessLogic;

public class CartB
{
    private readonly CompanyContext _context;
    private string? _idCartSession;
    private ILogger<CartController> _logger;

    public CartB(CompanyContext context, HttpContext httpContext, ILogger<CartController> logger)
    {
        this._context = context;
        this._logger = logger;
        _idCartSession = GetIdCartSession(httpContext);
    }

    private string? GetIdCartSession(HttpContext httpContext)
    {
        if (string.IsNullOrWhiteSpace(httpContext.Session.GetString("IdCartSession")))
        {
            if (!string.IsNullOrWhiteSpace(httpContext.User?.Identity?.Name))
            {
                httpContext.Session.SetString("IdCartSession", httpContext.User.Identity.Name);
            }
            else
            {
                httpContext.Session.SetString("IdCartSession", Guid.NewGuid().ToString());
            }
        }

        return httpContext.Session.GetString("IdCartSession") ?? string.Empty;
    }

    /// <summary>
    /// Handles adding items to existing cart
    /// </summary>
    /// <param name="product"></param>
    public async Task<bool> AddToCart(int productId)
    {
        try
        {
            var product = _context.Product.AsNoTracking().FirstOrDefault(p => p.IdProduct == productId);
            if (product == null)
                return false;

            var cartItem = await
            (
                from cartitem in _context.CartItem
                where cartitem.IdSessionOfCart == _idCartSession
                      && cartitem.IdProduct == product.IdProduct
                select cartitem
            ).FirstOrDefaultAsync();

            if (cartItem == null)
            {
                cartItem = new CartItem()
                {
                    IdProduct = product.IdProduct,
                    IdSessionOfCart = _idCartSession,
                    Quantity = 1,
                    CreatedDate = DateTime.Now
                };
                _context.CartItem.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Handles deleting items from cart
    /// </summary>
    /// <param name="product"></param>
    public async Task DeleteItemFromCart(Product product)
    {
        var cartItem = await
        (
            from cartitem in _context.CartItem
            where cartitem.IdSessionOfCart == _idCartSession
                  && cartitem.IdProduct == product.IdProduct
            select cartitem
        ).FirstOrDefaultAsync();
        if (cartItem != null)
        {
            _context.Remove(cartItem);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Handles deleting items from cart
    /// </summary>
    /// <param name="idCartItem"></param>
    public async Task<bool> DeleteItemFromCart(int idCartItem)
    {
        var cartItem = await _context.CartItem.FindAsync(idCartItem);
        if (cartItem == null)
            return false;
        _context.Remove(cartItem);
        await _context.SaveChangesAsync();
        return true;
    }


    /// <summary>
    /// It handles getting cart items!
    /// </summary>
    /// <returns></returns>
    public async Task<List<CartItem>> GetCartItems(bool asNoTracking = true)
        => asNoTracking
            ? await _context.CartItem
                .Where(ci => ci.IdSessionOfCart == _idCartSession)
                .Include(ci => ci.Product)
                .ToListAsync()
            : await _context.CartItem
                .Where(ci => ci.IdSessionOfCart == _idCartSession)
                .Include(ci => ci.Product)
                .ToListAsync();

    /// <summary>
    /// It handles getting cart total!
    /// </summary>
    /// <returns></returns>
    public async Task<decimal> GetTotal()
    {
        var items =
        (
            from element in _context.CartItem
            where element.IdSessionOfCart == _idCartSession
            select (decimal?)element.Quantity * element.Product.Price
        );

        return await items.SumAsync() ?? decimal.Zero;
    }
}