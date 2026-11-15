using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Clients.Messages.DTOs;
using SolutionOrders.Api.Features.Clients.Messages.Queries;
using SolutionOrders.Api.Features.Clients.Providers;

namespace SolutionOrders.Api.Features.Clients.Handlers.Queries;

public class GetClientByIdHandler(IClientProvider clientProvider)
    : IRequestHandler<GetClientByIdQuery, ClientDto?>
{
    public async Task<ClientDto?> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        =>
            (await clientProvider.GetClientByIdAsync(request.Id, true, cancellationToken))?
            .Adapt<ClientDto>();
}