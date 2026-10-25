using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Messages.Commands;
using SolutionOrders.Api.Features.Providers;
using SolutionOrders.Data.Data;

namespace SolutionOrders.Api.Features.Handlers.Commands
{
    public class UpdateItemHandler(IItemProvider itemProvider, ApplicationDbContext context, ILogger<UpdateItemHandler> logger)
        : IRequestHandler<UpdateItemCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await itemProvider.GetItemByIdAsync(request.IdItem, false, cancellationToken);
            logger.LogInformation("Updating item ID: {IdItem}", request.IdItem);
            request.Adapt(item);
            await context.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Updated item ID: {IdItem}", request.IdItem);
            return Unit.Value;  // MediatR Unit = void
        }
    }
}