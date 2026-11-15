using SolutionOrders.Data.Data;

namespace SolutionOrders.Api.Features.Item.Services
{
    public class ItemService(ApplicationDbContext context) : IItemService
    {
        public async Task CreateItem(Data.Models.Item item, CancellationToken cancellationToken)
        {
            context.Items.Add(item);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
