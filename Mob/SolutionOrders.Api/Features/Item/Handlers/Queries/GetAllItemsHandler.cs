using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Item.Messages.DTOs;
using SolutionOrders.Api.Features.Item.Messages.Queries;
using SolutionOrders.Api.Features.Item.Providers;

namespace SolutionOrders.Api.Features.Item.Handlers.Queries
{
    public class GetAllItemsHandler(IItemProvider itemProvider)
        : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDto>>
    {
        public async Task<IEnumerable<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
            =>
            (await itemProvider.GetAllItemsAsync(true, cancellationToken))
            .Adapt<IEnumerable<ItemDto>>();
    }
}
