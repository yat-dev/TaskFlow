using TaskFlow.Application.DTOs;
using TaskFlow.Application.Services.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Application.Services.Implementations;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    public async Task<ProjectDto?> GetByIdAsync(Guid id)
    {
        var project = await projectRepository.GetByIdAsync(id);
        
        return project is null ? null : new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            OwnerId = project.OwnerId
        };
    }

    public Task<ProjectDto?> GetWithTasksByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<ProjectDto>> GetAllAsync()
    {
        var projects = await projectRepository.GetAllAsync();
        
        return projects.Select(p => new ProjectDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            OwnerId = p.OwnerId
        });
    }

    
    public async Task<IEnumerable<ProjectDto>> GetByOwnerIdAsync(Guid ownerId)
    {
        var projects = await projectRepository.GetByOwnerIdAsync(ownerId);
        
        return projects.Select(p => new ProjectDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            OwnerId = p.OwnerId
        });
    }
    
    
    public async Task<ProjectDto> CreateAsync(ProjectDto project)
    {
        var entity = new ProjectEntity()
        {
            Id = Guid.NewGuid(),
            Name = project.Name,
            Description = project.Description,
            OwnerId = project.OwnerId
        };

        await projectRepository.AddAsync(entity);

        return new ProjectDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            OwnerId = entity.OwnerId
        };
    }

    
    public async Task UpdateAsync(ProjectDto project)
    {
        var entity = new ProjectEntity()
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            OwnerId = project.OwnerId
        };

        await projectRepository.UpdateAsync(entity);
    }

    
    public async Task DeleteAsync(Guid id)
    {
        var project = await projectRepository.GetByIdAsync(id);
        if (project != null)
            await projectRepository.DeleteAsync(project);
    }
}