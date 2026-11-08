using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Providers;

public interface IOrderProvider

{
    Task<IEnumerable<Order>> GetAllOrdersAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);
    Task<Order> GetOrderByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default);
}