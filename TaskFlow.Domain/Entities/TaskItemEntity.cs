using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class TaskItemEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public TaskState Status { get; set; } = TaskState.Todo;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid ProjectId { get; set; }
    public ProjectEntity Project { get; set; } = default!;

    public Guid? AssignedUserId { get; set; }
    public UserEntity? AssignedUser { get; set; }
}