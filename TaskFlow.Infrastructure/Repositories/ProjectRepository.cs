using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Infrastructure.Repositories;

public class ProjectRepository(TaskFlowDbContext context) : IProjectRepository
{
    public async Task<ProjectEntity?> GetByIdAsync(Guid id) => await context.Projects.FindAsync(id);

    public Task<ProjectEntity?> GetWithTasksByIdAsync(Guid id) =>
        context.Projects
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        Console.WriteLine("User: " + context.Database.GetDbConnection().ConnectionString);
        return await context.Projects.ToListAsync();
    }

    public async Task<IEnumerable<ProjectEntity>> GetByOwnerIdAsync(Guid ownerId) =>
        await context.Projects.Where(x => x.OwnerId == ownerId).ToListAsync();

    public async Task AddAsync(ProjectEntity project)
    {
        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProjectEntity project)
    {
        context.Projects.Update(project);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ProjectEntity project)
    {
        context.Projects.Remove(project);
        await context.SaveChangesAsync();
    }
}