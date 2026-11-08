using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Services
{
    public interface IItemService
    {
        public Task CreateItem(Item item, CancellationToken cancellationToken);
    }
}
