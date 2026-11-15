namespace SolutionOrders.Api.Features.Orders.Messages.DTOs;

public class CreateOrderItemDto
{
    public int IdItem { get; set; }
    public decimal? Quantity { get; set; }
}