using MediatR;
using SolutionOrders.Api.Features.UnitOfMeasurement.Messages.DTOs;

namespace SolutionOrders.Api.Features.UnitOfMeasurement.Messages.Queries;

public class GetAllUnitOfMeasurementsQuery: IRequest<IEnumerable<UnitOfMeasurementDto>>
{

}
