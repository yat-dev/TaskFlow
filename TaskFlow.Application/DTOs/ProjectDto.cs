namespace TaskFlow.Application.DTOs;

public class ProjectDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public Guid OwnerId { get; set; }
}