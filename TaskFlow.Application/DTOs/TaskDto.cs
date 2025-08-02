using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.DTOs;

public class TaskDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public TaskState Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public Guid ProjectId { get; set; }
    
    public Guid? AssignedUserId { get; set; }
}