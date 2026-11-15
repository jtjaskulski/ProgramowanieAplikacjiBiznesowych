using Mapster;
using MediatR;
using SolutionOrders.Api.Features.Orders.Messages.Commands;
using SolutionOrders.Api.Features.Orders.Services;
using SolutionOrders.Data.Models;

namespace SolutionOrders.Api.Features.Orders.Handlers.Commands;

public class CreateOrderHandler(IOrderService orderService, ILogger<CreateOrderHandler> logger)
    : IRequestHandler<CreateOrderCommand, int>
{
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new Order for Client {IdClient}", request.IdClient);

        var order = new Order
        {
            DataOrder = DateTime.UtcNow,
            IdClient = request.IdClient,
            IdWorker = request.IdWorker,
            Notes = request.Notes,
            DeliveryDate = request.DeliveryDate,
            OrderItems = request.OrderItems.Adapt<List<OrderItem>>()
        };

        await orderService.CreateOrder(order, cancellationToken);
        logger.LogInformation("Created order ID: {IdOrder}", order.IdOrder);
        return order.IdOrder;
    }
}