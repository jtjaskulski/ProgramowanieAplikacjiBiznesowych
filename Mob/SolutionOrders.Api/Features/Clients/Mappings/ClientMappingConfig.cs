using Mapster;
using SolutionOrders.Api.Features.Clients.Messages.Commands;
using SolutionOrders.Api.Features.Clients.Messages.DTOs;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Clients.Mappings;

public class ClientMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Client, ClientDto>();

        config.NewConfig<CreateClientCommand, Client>()
            .Map(dest => dest.IsActive, _ => true)
            .Ignore(dest => dest.IdClient)
            .Ignore(dest => dest.Orders);

        config.NewConfig<UpdateClientCommand, Client>()
            .Ignore(dest => dest.IdClient)
            .Ignore(dest => dest.Orders);
    }
}