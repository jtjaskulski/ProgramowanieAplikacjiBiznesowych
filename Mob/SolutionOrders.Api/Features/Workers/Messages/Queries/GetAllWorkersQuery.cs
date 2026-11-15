using MediatR;
using SolutionOrders.Api.Features.Workers.Messages.DTOs;

namespace SolutionOrders.Api.Features.Workers.Messages.Queries;

public class GetAllWorkersQuery : IRequest<IEnumerable<WorkerDto>>
{
}