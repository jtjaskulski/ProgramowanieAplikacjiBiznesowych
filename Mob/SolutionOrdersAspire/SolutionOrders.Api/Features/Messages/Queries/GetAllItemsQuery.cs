using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;

namespace SolutionOrders.Api.Features.Messages.Queries
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
    }
}
