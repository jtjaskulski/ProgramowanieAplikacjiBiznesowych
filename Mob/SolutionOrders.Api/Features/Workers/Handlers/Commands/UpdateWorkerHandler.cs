using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Workers.Messages.Commands;
using SolutionOrders.Api.Features.Workers.Providers;
using SolutionOrders.Data.Data;

namespace SolutionOrders.Api.Features.Workers.Handlers.Commands;

public class UpdateWorkerHandler(IWorkerProvider workerProvider, ApplicationDbContext context, ILogger<UpdateWorkerHandler> logger)
    : IRequestHandler<UpdateWorkerCommand, Unit>
{
    public async Task<Unit> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = await workerProvider.GetWorkerByIdAsync(request.IdWorker, false, cancellationToken);
        logger.LogInformation("Updating worker ID: {IdWorker}", request.IdWorker);
        request.Adapt(worker);
        await context.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Updated worker ID: {IdWorker}", request.IdWorker);
        return Unit.Value;
    }
}