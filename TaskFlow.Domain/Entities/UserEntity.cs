using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public UserRole Role { get; set; }

    public ICollection<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    public ICollection<TaskItemEntity> Tasks { get; set; } = new List<TaskItemEntity>();
}