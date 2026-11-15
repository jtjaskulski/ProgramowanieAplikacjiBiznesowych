using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Orders.Services;

public interface IOrderService
{
    Task CreateOrder(Order order, CancellationToken cancellationToken);
}