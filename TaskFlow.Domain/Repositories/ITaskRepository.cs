using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Repositories;

public interface ITaskRepository
{
    Task<TaskItemEntity?> GetByIdAsync(Guid id);
    
    Task<IEnumerable<TaskItemEntity>> GetAllAsync();
    
    Task<IEnumerable<TaskItemEntity>> GetAllByProjectIdAsync(Guid projectId);
    
    Task<IEnumerable<TaskItemEntity>> GetAssignedToUserAsync(Guid userId);
    
    Task<TaskItemEntity?> GetWithDetailsByIdAsync(Guid id);
    
    Task AddAsync(TaskItemEntity task);
    
    Task UpdateAsync(TaskItemEntity task);
    
    Task DeleteAsync(TaskItemEntity task);
}