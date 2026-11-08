using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Providers;

public interface IUnitOfMeasurementProvider
{
    
    /// <summary>
    /// Method to get all UnitOfMeasurements from the database.
    /// The AsNoTracking parameter allows you to specify whether the entities should be tracked by the context or not.
    /// If set to true, the entities will not be tracked, which can improve performance when you only need to read data
    /// without making changes.
    /// </summary>
    /// <param name="asNoTracking">Specifies whether the entities should be tracked by the context.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A collection of UnitOfMeasurements.</returns>
    Task<IEnumerable<UnitOfMeasurement>> GetAllUnitOfMeasurementsAsync(bool asNoTracking = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves an UnitOfMeasurement by its unique identifier.
    /// </summary>
    /// <remarks>Use this method when the UnitOfMeasurement may not exist or when you want to control entity
    /// tracking behavior. If the UnitOfMeasurement does not exist, the method returns <see langword="null"/>. Cancelling the
    /// provided token will abort the operation.</remarks>
    /// <param name="id">The unique identifier of the UnitOfMeasurement to retrieve. Must be a positive integer.</param>
    /// <param name="asNoTracking">Indicates whether the UnitOfMeasurement should be retrieved without tracking changes in the context. Specify <see
    /// langword="true"/> to disable change tracking; otherwise, <see langword="false"/>.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the UnitOfMeasurement if found; otherwise,
    /// <see langword="null"/>.</returns>
    Task<UnitOfMeasurement> GetUnitOfMeasurementByIdAsync(int id, bool asNoTracking = true, CancellationToken cancellationToken = default);
}
