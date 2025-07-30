using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Repositories;

public interface IProjectRepository
{
    Task<ProjectEntity?> GetByIdAsync(Guid id);
    
    Task<ProjectEntity?> GetWithTasksByIdAsync(Guid id);
    
    Task<IEnumerable<ProjectEntity>> GetAllAsync();
    
    Task<IEnumerable<ProjectEntity>> GetByOwnerIdAsync(Guid ownerId);
    
    Task AddAsync(ProjectEntity projectEntity);
    
    Task UpdateAsync(ProjectEntity projectEntity);
    
    Task DeleteAsync(ProjectEntity projectEntity);
}