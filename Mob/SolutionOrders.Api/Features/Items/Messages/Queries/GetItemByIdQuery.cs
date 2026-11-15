using MediatR;
using SolutionOrders.Api.Features.Items.Messages.DTOs;

namespace SolutionOrders.Api.Features.Items.Messages.Queries
{
    public class GetItemByIdQuery(int id) : IRequest<ItemDto?>
    {
        public int Id { get; set; } = id;
    }
}
