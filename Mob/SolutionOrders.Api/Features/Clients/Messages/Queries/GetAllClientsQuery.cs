using MediatR;
using SolutionOrders.Api.Features.Clients.Messages.DTOs;

namespace SolutionOrders.Api.Features.Clients.Messages.Queries;

public class GetAllClientsQuery : IRequest<IEnumerable<ClientDto>>
{
    
}