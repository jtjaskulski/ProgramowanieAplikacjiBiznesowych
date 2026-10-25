using MediatR;

namespace SolutionOrders.Api.Features.Messages.Commands
{
    public class UpdateItemCommand : IRequest<Unit>
    {
        public int IdItem { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int IdCategory { get; set; }
        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
        public string? FotoUrl { get; set; }
        public int? IdUnitOfMeasurement { get; set; }
        public string? Code { get; set; }
    }
}
