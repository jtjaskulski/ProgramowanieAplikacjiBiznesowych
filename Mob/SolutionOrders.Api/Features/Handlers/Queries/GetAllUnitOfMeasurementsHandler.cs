using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;
using SolutionOrders.Api.Features.Messages.Queries;
using SolutionOrders.Api.Features.Providers;

namespace SolutionOrders.Api.Features.Handlers.Queries;

public class GetAllUnitOfMeasurementsHandler(IUnitOfMeasurementProvider unitOfMeasurementProvider) :
    IRequestHandler<GetAllUnitOfMeasurementsQuery, IEnumerable<UnitOfMeasurementDto>>
{
    public async Task<IEnumerable<UnitOfMeasurementDto>> Handle(GetAllUnitOfMeasurementsQuery request, CancellationToken cancellationToken)
        =>
        (await unitOfMeasurementProvider.GetAllUnitOfMeasurementsAsync(true, cancellationToken))
        .Adapt<IEnumerable<UnitOfMeasurementDto>>();        
}