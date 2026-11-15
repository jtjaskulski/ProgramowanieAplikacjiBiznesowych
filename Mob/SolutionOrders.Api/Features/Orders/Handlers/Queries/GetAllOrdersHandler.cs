using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Orders.Messages.DTOs;
using SolutionOrders.Api.Features.Orders.Messages.Queries;
using SolutionOrders.Api.Features.Orders.Providers;

namespace SolutionOrders.Api.Features.Orders.Handlers.Queries;

public class GetAllOrdersHandler(IOrderProvider orderProvider)
    : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        =>
            (await orderProvider.GetAllOrdersAsync(true, cancellationToken))
            .Adapt<IEnumerable<OrderDto>>();
}