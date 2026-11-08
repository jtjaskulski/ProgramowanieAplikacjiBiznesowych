using SolutionOrders.Data.Data;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Services;

public class OrderService(ApplicationDbContext context) : IOrderService
{
    public async Task CreateOrder(Order order, CancellationToken cancellationToken)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync(cancellationToken);
    }
}