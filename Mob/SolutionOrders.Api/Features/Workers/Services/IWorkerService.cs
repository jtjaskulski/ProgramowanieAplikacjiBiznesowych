using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Workers.Services;

public interface IWorkerService
{
    Task CreateWorker(Worker worker, CancellationToken cancellationToken);
}