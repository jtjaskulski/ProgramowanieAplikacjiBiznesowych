using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Clients.Messages.Commands;
using SolutionOrders.Api.Features.Clients.Providers;
using SolutionOrders.Data.Data;

namespace SolutionOrders.Api.Features.Clients.Handlers.Commands;

public class UpdateClientHandler(IClientProvider clientProvider, ApplicationDbContext context, ILogger<UpdateClientHandler> logger)
    : IRequestHandler<UpdateClientCommand, Unit>
{
    public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await clientProvider.GetClientByIdAsync(request.IdClient, false, cancellationToken);
        logger.LogInformation("Updating client ID: {IdClient}", request.IdClient);
        request.Adapt(client);
        await context.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Updated client ID: {IdClient}", request.IdClient);
        return Unit.Value;
    }
}