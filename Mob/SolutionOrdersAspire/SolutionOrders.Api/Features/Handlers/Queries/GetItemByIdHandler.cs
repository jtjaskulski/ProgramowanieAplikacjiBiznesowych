using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;
using SolutionOrders.Api.Features.Messages.Queries;
using SolutionOrders.Api.Features.Providers;

namespace SolutionOrders.Api.Features.Handlers.Queries
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
