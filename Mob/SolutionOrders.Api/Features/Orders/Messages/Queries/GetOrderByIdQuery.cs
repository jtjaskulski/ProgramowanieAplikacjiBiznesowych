using MediatR;
using SolutionOrders.Api.Features.Orders.Messages.DTOs;

namespace SolutionOrders.Api.Features.Orders.Messages.Queries;

public class GetOrderByIdQuery(int id) : IRequest<OrderDto?>
{
    public int Id { get; set; } = id;
}