namespace SolutionOrders.Api.Features.Messages.DTOs;

public class WorkerDto
{
    public int IdWorker { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; }
    public string Login { get; set; } = string.Empty;
}