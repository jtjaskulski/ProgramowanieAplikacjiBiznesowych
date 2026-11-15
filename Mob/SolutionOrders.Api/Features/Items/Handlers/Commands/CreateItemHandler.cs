using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Items.Messages.Commands;
using SolutionOrders.Api.Features.Items.Services;

namespace SolutionOrders.Api.Features.Items.Handlers.Commands
{
    public class CreateItemHandler(IItemService itemService, ILogger<CreateItemHandler> logger)
        : IRequestHandler<CreateItemCommand, int>
    {
        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new Item: {Name}", request.Name);
            logger.LogInformation("Request details: {@Request}", request);
            var item = request.Adapt<Data.Models.Item>();
            await itemService.CreateItem(item, cancellationToken);
            logger.LogInformation("Created item ID: {IdItem}", item.IdItem);
            return item.IdItem;
        }
    }
}