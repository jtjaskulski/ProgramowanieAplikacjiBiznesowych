using Microsoft.EntityFrameworkCore;
using SolutionOrders.Data.Data;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Providers;

public class UnitOfMeasurementProvider(ApplicationDbContext context) : IUnitOfMeasurementProvider
{
    public async Task<IEnumerable<UnitOfMeasurement>> GetAllUnitOfMeasurementsAsync(bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        var query = context.UnitOfMeasurements 
            .Where(i => i.IsActive);

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query
            .OrderBy(unitOfMeasurement => unitOfMeasurement.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<UnitOfMeasurement> GetUnitOfMeasurementByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = context.UnitOfMeasurements 
            .Where(i => i.IsActive);

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        var unitOfMeasurement = await query
            .FirstOrDefaultAsync(i => i.IdUnitOfMeasurement == id, cancellationToken);

        return unitOfMeasurement ?? throw new KeyNotFoundException($"Jednostka miary o ID {id} nie istnieje");
    }
}
