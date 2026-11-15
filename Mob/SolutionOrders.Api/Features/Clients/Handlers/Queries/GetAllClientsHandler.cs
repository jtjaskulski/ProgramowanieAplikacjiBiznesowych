using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Clients.Messages.DTOs;
using SolutionOrders.Api.Features.Clients.Messages.Queries;
using SolutionOrders.Api.Features.Clients.Providers;

namespace SolutionOrders.Api.Features.Clients.Handlers.Queries;

public class GetAllClientsHandler(IClientProvider clientProvider)
    : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDto>>
{
    public async Task<IEnumerable<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        =>
            (await clientProvider.GetAllClientsAsync(true, cancellationToken))
            .Adapt<IEnumerable<ClientDto>>();
}