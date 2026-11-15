using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Items.Messages.DTOs;
using SolutionOrders.Api.Features.Items.Messages.Queries;
using SolutionOrders.Api.Features.Items.Providers;

namespace SolutionOrders.Api.Features.Items.Handlers.Queries
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
