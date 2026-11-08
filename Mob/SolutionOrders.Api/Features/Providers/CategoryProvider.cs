using Microsoft.EntityFrameworkCore;
using SolutionOrders.Data.Data;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Providers;

public class CategoryProvider (ApplicationDbContext context) : ICategoryProvider
{
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        var query = context.Categories 
            .Where(i => i.IsActive);

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query
            .OrderBy(category => category.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<Category> GetCategoryByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = context.Categories 
            .Where(i => i.IsActive);

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        var category = await query
            .FirstOrDefaultAsync(i => i.IdCategory == id, cancellationToken);

        return category ?? throw new KeyNotFoundException($"Jednostka miary o ID {id} nie istnieje");
    }
}
