using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Services.Interfaces;

public interface IProjectService
{
    Task<ProjectDto?> GetByIdAsync(Guid id);
    
    Task<ProjectDto?> GetWithTasksByIdAsync(Guid id);

    Task<IEnumerable<ProjectDto>> GetAllAsync();

    Task<IEnumerable<ProjectDto>> GetByOwnerIdAsync(Guid ownerId);

    Task<ProjectDto> CreateAsync(ProjectDto project);

    Task UpdateAsync(ProjectDto project);

    Task DeleteAsync(Guid id);
}