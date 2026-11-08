using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;

namespace SolutionOrders.Api.Features.Messages.Queries
{
    public class GetItemByIdQuery(int id) : IRequest<ItemDto?>
    {
        public int Id { get; set; } = id;
    }
}
