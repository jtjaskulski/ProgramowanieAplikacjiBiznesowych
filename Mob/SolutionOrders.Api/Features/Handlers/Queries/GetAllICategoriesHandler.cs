using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;
using SolutionOrders.Api.Features.Messages.Queries;
using SolutionOrders.Api.Features.Providers;

namespace SolutionOrders.Api.Features.Handlers.Queries
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
