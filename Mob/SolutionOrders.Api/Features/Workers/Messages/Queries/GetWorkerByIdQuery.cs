using MediatR;
using SolutionOrders.Api.Features.Workers.Messages.DTOs;

namespace SolutionOrders.Api.Features.Workers.Messages.Queries;

public class GetWorkerByIdQuery(int id) : IRequest<WorkerDto?>
{
    public int Id { get; set; } = id;
}