using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Categories.Messages.DTOs;
using SolutionOrders.Api.Features.Categories.Messages.Queries;
using SolutionOrders.Api.Features.Categories.Providers;

namespace SolutionOrders.Api.Features.Categories.Handlers.Queries
{
    public class GetAllICategoriesHandler(ICategoryProvider categoryProvider)
        : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            =>
            (await categoryProvider.GetAllCategoriesAsync(true, cancellationToken))
            .Adapt<IEnumerable<CategoryDto>>();
    }
}
