namespace SolutionOrders.Api.Features.Item.Services
{
    public interface IItemService
    {
        public Task CreateItem(Data.Models.Item item, CancellationToken cancellationToken);
    }
}
