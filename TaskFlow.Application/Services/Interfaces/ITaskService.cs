using TaskFlow.Application.DTOs;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Services.Interfaces;

public interface ITaskService
{
    Task<TaskDto?> GetByIdAsync(Guid id);
    
    Task<IEnumerable<TaskDto>> GetAllAsync();
    
    Task<TaskDto?> GetWithDetailsByIdAsync(Guid id);
    
    Task<IEnumerable<TaskDto>> GetByProjectIdAsync(Guid projectId);
    
    Task<IEnumerable<TaskDto>> GetByAssignedUserIdAsync(Guid userId);
    
    Task<TaskDto> CreateAsync(TaskDto task);
    
    Task UpdateAsync(TaskDto task);
    
    Task DeleteAsync(Guid id);
}