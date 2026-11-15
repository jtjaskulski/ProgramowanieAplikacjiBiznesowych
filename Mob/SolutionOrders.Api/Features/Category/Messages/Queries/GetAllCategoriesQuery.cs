using MediatR;
using SolutionOrders.Api.Features.Category.Messages.DTOs;

namespace SolutionOrders.Api.Features.Category.Messages.Queries;

public class GetAllCategoriesQuery: IRequest<IEnumerable<CategoryDto>>
{
}
