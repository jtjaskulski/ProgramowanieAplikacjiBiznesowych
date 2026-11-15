using Mapster;
using MediatR;
using SolutionOrders.Api.Features.UnitOfMeasurement.Messages.DTOs;
using SolutionOrders.Api.Features.UnitOfMeasurement.Messages.Queries;
using SolutionOrders.Api.Features.UnitOfMeasurement.Providers;

namespace SolutionOrders.Api.Features.UnitOfMeasurement.Handlers.Queries;

public class GetAllUnitOfMeasurementsHandler(IUnitOfMeasurementProvider unitOfMeasurementProvider) :
    IRequestHandler<GetAllUnitOfMeasurementsQuery, IEnumerable<UnitOfMeasurementDto>>
{
    public async Task<IEnumerable<UnitOfMeasurementDto>> Handle(GetAllUnitOfMeasurementsQuery request, CancellationToken cancellationToken)
        =>
        (await unitOfMeasurementProvider.GetAllUnitOfMeasurementsAsync(true, cancellationToken))
        .Adapt<IEnumerable<UnitOfMeasurementDto>>();        
}