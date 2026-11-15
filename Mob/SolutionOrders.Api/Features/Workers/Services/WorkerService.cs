using SolutionOrders.Data.Data;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Workers.Services;

public class WorkerService(ApplicationDbContext context) : IWorkerService
{
    public async Task CreateWorker(Worker worker, CancellationToken cancellationToken)
    {
        context.Workers.Add(worker);
        await context.SaveChangesAsync(cancellationToken);
    }
}