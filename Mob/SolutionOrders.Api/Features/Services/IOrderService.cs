using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Services;

public interface IOrderService
{
    Task CreateOrder(Order order, CancellationToken cancellationToken);
}