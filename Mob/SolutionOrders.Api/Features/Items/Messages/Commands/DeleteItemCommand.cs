using MediatR;

namespace SolutionOrders.Api.Features.Items.Messages.Commands
{
    public class DeleteItemCommand(int id) : IRequest<Unit>
    {
        public int IdItem { get; set; } = id;
    }
}
