using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;
using SolutionOrders.Api.Features.Messages.Queries;
using SolutionOrders.Api.Features.Providers;

namespace SolutionOrders.Api.Features.Handlers;

public class GetAllOrdersHandler(IOrderProvider orderProvider)
    : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        =>
            (await orderProvider.GetAllOrdersAsync(true, cancellationToken))
            .Adapt<IEnumerable<OrderDto>>();
}