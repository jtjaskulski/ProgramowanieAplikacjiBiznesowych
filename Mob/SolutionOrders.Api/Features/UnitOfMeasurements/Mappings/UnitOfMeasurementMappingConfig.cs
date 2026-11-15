using Mapster;
using SolutionOrders.Api.Features.UnitOfMeasurements.Messages.DTOs;

namespace SolutionOrders.Api.Features.UnitOfMeasurements.Mappings;

public class UnitOfMeasurementMappingConfig
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Data.Models.UnitOfMeasurement, UnitOfMeasurementDto>();
    }
}