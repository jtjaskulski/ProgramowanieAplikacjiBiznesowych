using MediatR;
using SolutionOrders.Api.Features.Messages.DTOs;

namespace SolutionOrders.Api.Features.Messages.Queries;

public class GetAllOrdersQuery: IRequest<List<OrderDto>>
{
    // Opcjonalne filtry
    public int? ClientId { get; set; }
    public int? WorkerId { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public bool IncludeInactive { get; set; } = false;
}