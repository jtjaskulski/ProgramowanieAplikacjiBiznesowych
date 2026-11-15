using MediatR;
using SolutionOrders.Api.Features.Orders.Messages.DTOs;

namespace SolutionOrders.Api.Features.Orders.Messages.Queries;

public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
{
}