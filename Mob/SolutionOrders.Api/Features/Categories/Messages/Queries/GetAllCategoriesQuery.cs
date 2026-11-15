using MediatR;
using SolutionOrders.Api.Features.Categories.Messages.DTOs;

namespace SolutionOrders.Api.Features.Categories.Messages.Queries;

public class GetAllCategoriesQuery: IRequest<IEnumerable<CategoryDto>>
{
}
