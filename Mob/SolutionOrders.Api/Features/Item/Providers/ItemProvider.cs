using Microsoft.EntityFrameworkCore;
using SolutionOrders.Data.Data;

namespace SolutionOrders.Api.Features.Item.Providers
{
    public class ItemProvider(ApplicationDbContext context) : IItemProvider
    {
        public async Task<IEnumerable<Data.Models.Item>> GetAllItemsAsync(bool asNoTracking = true,
            CancellationToken cancellationToken = default)
        {
            var query = context.Items
                .Include(i => i.Category)
                .Include(i => i.UnitOfMeasurement)
                .Where(i => i.IsActive);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .OrderBy(item => item.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<Data.Models.Item> GetItemByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
        {
            var query = context.Items
                .Include(i => i.Category)
                .Include(i => i.UnitOfMeasurement)
                .Where(i => i.IsActive);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            var item = await query
                .FirstOrDefaultAsync(i => i.IdItem == id, cancellationToken);

            return item ?? throw new KeyNotFoundException($"Produkt o ID {id} nie istnieje");
        }
    }
}
