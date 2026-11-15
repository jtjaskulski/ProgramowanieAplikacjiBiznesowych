using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Item.Messages.DTOs;
using SolutionOrders.Api.Features.Item.Messages.Queries;
using SolutionOrders.Api.Features.Item.Providers;

namespace SolutionOrders.Api.Features.Item.Handlers.Queries
{
    public class GetItemByIdHandler(IItemProvider itemProvider)
        : IRequestHandler<GetItemByIdQuery, ItemDto?>
    {
        public async Task<ItemDto?> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
            =>
            (await itemProvider.GetItemByIdAsync(request.Id, true, cancellationToken))
            .Adapt<ItemDto>();
    }
}
