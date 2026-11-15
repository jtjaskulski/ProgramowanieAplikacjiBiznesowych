using Mapster;
using MediatR;
using SolutionOrders.Api.Features.UnitOfMeasurements.Messages.DTOs;
using SolutionOrders.Api.Features.UnitOfMeasurements.Messages.Queries;
using SolutionOrders.Api.Features.UnitOfMeasurements.Providers;

namespace SolutionOrders.Api.Features.UnitOfMeasurements.Handlers.Queries;

public class GetAllUnitOfMeasurementsHandler(IUnitOfMeasurementProvider unitOfMeasurementProvider) :
    IRequestHandler<GetAllUnitOfMeasurementsQuery, IEnumerable<UnitOfMeasurementDto>>
{
    public async Task<IEnumerable<UnitOfMeasurementDto>> Handle(GetAllUnitOfMeasurementsQuery request, CancellationToken cancellationToken)
        =>
        (await unitOfMeasurementProvider.GetAllUnitOfMeasurementsAsync(true, cancellationToken))
        .Adapt<IEnumerable<UnitOfMeasurementDto>>();        
}