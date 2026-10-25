using MediatR;
using SolutionOrders.Api.Features.Messages.Commands;
using SolutionOrders.Api.Features.Providers;
using SolutionOrders.Data.Data;

namespace SolutionOrders.Api.Features.Handlers.Commands
{
    public class DeleteItemHandler(IItemProvider itemProvider,
        ApplicationDbContext context, ILogger<DeleteItemHandler> logger)
        : IRequestHandler<DeleteItemCommand, Unit>
    {
        public async Task<Unit> Handle(
            DeleteItemCommand request,
            CancellationToken cancellationToken)
        {
            var item = await itemProvider.GetItemByIdAsync(request.IdItem, false, cancellationToken);
            logger.LogInformation("Deleting item ID: {IdItem}", request.IdItem);

            item.IsActive = false;
            await context.SaveChangesAsync(cancellationToken);

            // or hard delete:
            // _context.Items.Remove(item);
            // await _context.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Deleted item ID: {IdItem}", request.IdItem);
            return Unit.Value;
        }
    }
}