using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;

namespace SolutionOrders.Api.Features.Messages.Queries;

public class GetAllCategoriesQuery: IRequest<IEnumerable<CategoryDto>>
{
}
