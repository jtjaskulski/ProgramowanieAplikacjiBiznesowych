using MediatR;
using SolutionOrders.Api.Features.Item.Messages.DTOs;

namespace SolutionOrders.Api.Features.Item.Messages.Queries
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
    }
}
