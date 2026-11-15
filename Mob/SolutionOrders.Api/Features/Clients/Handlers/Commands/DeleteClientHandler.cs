using MediatR;
using SolutionOrders.Api.Features.Clients.Messages.Commands;
using SolutionOrders.Api.Features.Clients.Providers;
using SolutionOrders.Data.Data;

namespace SolutionOrders.Api.Features.Clients.Handlers.Commands;

public class DeleteClientHandler(IClientProvider clientProvider, ApplicationDbContext context, ILogger<DeleteClientHandler> logger)
    : IRequestHandler<DeleteClientCommand, Unit>
{
    public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await clientProvider.GetClientByIdAsync(request.IdClient, false, cancellationToken);
        logger.LogInformation("Deleting client ID: {IdClient}", request.IdClient);
        client.IsActive = false;
        await context.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Deleted client ID: {IdClient}", request.IdClient);
        return Unit.Value;
    }
}