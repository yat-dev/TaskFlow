using TaskFlow.Application.DTOs;
using TaskFlow.Application.Services.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Application.Services.Implementations;

public class TaskService(ITaskRepository taskRepository) : ITaskService
{
    public async Task<TaskDto?> GetByIdAsync(Guid id)
    {
        var task = await taskRepository.GetByIdAsync(id);
        return task is null ? null : ToDto(task);
    }

    public async Task<IEnumerable<TaskDto>> GetAllAsync()
    {
        var tasks = await taskRepository.GetAllAsync();
        
        return tasks.Select(ToDto);
    }

    public async Task<TaskDto?> GetWithDetailsByIdAsync(Guid id)
    {
        var task = await taskRepository.GetWithDetailsByIdAsync(id);
        return task is null ? null : ToDto(task);
    }

    public async Task<IEnumerable<TaskDto>> GetByProjectIdAsync(Guid projectId)
    {
        var tasks = await taskRepository.GetAllByProjectIdAsync(projectId);
        return tasks.Select(ToDto);
    }

    public async Task<IEnumerable<TaskDto>> GetByAssignedUserIdAsync(Guid userId)
    {
        var tasks = await taskRepository.GetAssignedToUserAsync(userId);
        return tasks.Select(ToDto);
    }

    public async Task<TaskDto> CreateAsync(TaskDto task)
    {
        var entity = new TaskItemEntity()
        {
            Id = Guid.NewGuid(),
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            CreatedAt = DateTime.UtcNow,
            ProjectId = task.ProjectId,
            AssignedUserId = task.AssignedUserId
        };

        await taskRepository.AddAsync(entity);
        return ToDto(entity);
    }

    public async Task UpdateAsync(TaskDto task)
    {
        var entity = new TaskItemEntity()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            CreatedAt = task.CreatedAt,
            ProjectId = task.ProjectId,
            AssignedUserId = task.AssignedUserId
        };

        await taskRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await taskRepository.GetByIdAsync(id);
        if (task != null)
            await taskRepository.DeleteAsync(task);
    }

    private static TaskDto ToDto(TaskItemEntity task) => new()
    {
        Id = task.Id,
        Title = task.Title,
        Description = task.Description,
        Status = task.Status,
        CreatedAt = task.CreatedAt,
        ProjectId = task.ProjectId,
        AssignedUserId = task.AssignedUserId
    };
}
