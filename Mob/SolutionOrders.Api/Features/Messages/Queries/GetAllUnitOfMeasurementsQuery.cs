using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;

namespace SolutionOrders.Api.Features.Messages.Queries;

public class GetAllUnitOfMeasurementsQuery: IRequest<IEnumerable<UnitOfMeasurementDto>>
{

}
