using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Orders.Messages.DTOs;
using SolutionOrders.Api.Features.Orders.Messages.Queries;
using SolutionOrders.Api.Features.Orders.Providers;

namespace SolutionOrders.Api.Features.Orders.Handlers.Queries;

public class GetOrderByIdHandler(IOrderProvider orderProvider)
    : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        =>
            (await orderProvider.GetOrderByIdAsync(request.Id, true, cancellationToken))?
            .Adapt<OrderDto>();
}