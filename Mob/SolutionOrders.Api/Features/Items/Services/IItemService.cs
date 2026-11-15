namespace SolutionOrders.Api.Features.Items.Services
{
    public interface IItemService
    {
        public Task CreateItem(Data.Models.Item item, CancellationToken cancellationToken);
    }
}
