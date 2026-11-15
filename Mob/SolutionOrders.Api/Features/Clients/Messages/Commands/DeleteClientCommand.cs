using MediatR;

namespace SolutionOrders.Api.Features.Clients.Messages.Commands;

public class DeleteClientCommand(int idClient) : IRequest<Unit>
{
    public int IdClient { get; set; } = idClient;
}