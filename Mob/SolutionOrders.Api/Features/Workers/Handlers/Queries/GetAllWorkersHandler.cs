using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Workers.Messages.DTOs;
using SolutionOrders.Api.Features.Workers.Messages.Queries;
using SolutionOrders.Api.Features.Workers.Providers;

namespace SolutionOrders.Api.Features.Workers.Handlers.Queries;

public class GetAllWorkersHandler(IWorkerProvider workerProvider)
    : IRequestHandler<GetAllWorkersQuery, IEnumerable<WorkerDto>>
{
    public async Task<IEnumerable<WorkerDto>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
        =>
            (await workerProvider.GetAllWorkersAsync(true, cancellationToken))
            .Adapt<IEnumerable<WorkerDto>>();
}