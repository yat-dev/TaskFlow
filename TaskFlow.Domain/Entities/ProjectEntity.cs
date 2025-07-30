namespace TaskFlow.Domain.Entities;

public class ProjectEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = string.Empty;

    public Guid OwnerId { get; set; }
    public UserEntity Owner { get; set; } = default!;

    public ICollection<TaskItemEntity> Tasks { get; set; } = new List<TaskItemEntity>();
}