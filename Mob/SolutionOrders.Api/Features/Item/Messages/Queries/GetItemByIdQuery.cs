using MediatR;
using SolutionOrders.Api.Features.Item.Messages.DTOs;

namespace SolutionOrders.Api.Features.Item.Messages.Queries
{
    public class GetItemByIdQuery(int id) : IRequest<ItemDto?>
    {
        public int Id { get; set; } = id;
    }
}
