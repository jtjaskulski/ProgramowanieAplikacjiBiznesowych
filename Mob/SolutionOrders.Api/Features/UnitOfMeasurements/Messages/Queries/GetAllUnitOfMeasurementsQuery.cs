using MediatR;
using SolutionOrders.Api.Features.UnitOfMeasurements.Messages.DTOs;

namespace SolutionOrders.Api.Features.UnitOfMeasurements.Messages.Queries;

public class GetAllUnitOfMeasurementsQuery: IRequest<IEnumerable<UnitOfMeasurementDto>>
{

}
