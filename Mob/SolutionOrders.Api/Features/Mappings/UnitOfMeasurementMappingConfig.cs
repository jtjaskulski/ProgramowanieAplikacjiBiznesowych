using Mapster;
using SolutionOrders.Api.Features.Messages.DTOs;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Mappings;

public class UnitOfMeasurementMappingConfig
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UnitOfMeasurement, UnitOfMeasurementDto>();
    }
}