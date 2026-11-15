using SolutionOrders.Data.Data;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Clients.Services;

public class ClientService(ApplicationDbContext context) : IClientService
{
    public async Task CreateClient(Client client, CancellationToken cancellationToken)
    {
        context.Clients.Add(client);
        await context.SaveChangesAsync(cancellationToken);
    }
}