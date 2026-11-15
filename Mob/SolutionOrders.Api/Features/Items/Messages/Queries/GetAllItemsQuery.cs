using MediatR;
using SolutionOrders.Api.Features.Items.Messages.DTOs;

namespace SolutionOrders.Api.Features.Items.Messages.Queries
{
    public class GetAllItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
    }
}
