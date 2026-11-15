using MediatR;
using SolutionOrders.Api.Features.Clients.Messages.DTOs;

namespace SolutionOrders.Api.Features.Clients.Messages.Queries;

public class GetClientByIdQuery(int id) : IRequest<ClientDto?>
{
    public int Id { get; set; } = id;
}