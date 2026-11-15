using Mapster;
using SolutionOrders.Api.Features.UnitOfMeasurement.Messages.DTOs;

namespace SolutionOrders.Api.Features.UnitOfMeasurement.Mappings;

public class UnitOfMeasurementMappingConfig
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Data.Models.UnitOfMeasurement, UnitOfMeasurementDto>();
    }
}