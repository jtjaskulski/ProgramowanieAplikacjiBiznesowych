using Company.Data.Models.Shop;

namespace Company.PortalWWW.ViewModels;

public class CartViewModel
{
    public List<CartItem> CartItems { get; set; } = [];
    public decimal Total { get; set; }
}