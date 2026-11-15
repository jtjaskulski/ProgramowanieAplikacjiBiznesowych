using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Clients.Services;

public interface IClientService
{
    Task CreateClient(Client client, CancellationToken cancellationToken);
}