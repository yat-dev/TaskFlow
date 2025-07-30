using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Infrastructure.Repositories;

public class TaskRepository(TaskFlowDbContext context) : ITaskRepository
{
    // 🟢 Méthode simple par ID (clé primaire, sans navigation)
    public async Task<TaskItemEntity?> GetByIdAsync(Guid id) =>
        await context.Tasks.FindAsync(id).AsTask();

    public async Task<IEnumerable<TaskItemEntity>> GetAllAsync() => await context.Tasks.ToListAsync();

    // 🟢 Méthode simple : toutes les tâches d’un projet (sans include)
    public async Task<IEnumerable<TaskItemEntity>> GetAllByProjectIdAsync(Guid projectId) =>
        await context.Tasks
            .Where(t => t.ProjectId == projectId)
            .ToListAsync();

    // 🟢 Méthode simple : toutes les tâches assignées à un utilisateur (sans include)
    public async Task<IEnumerable<TaskItemEntity>> GetAssignedToUserAsync(Guid userId) =>
        await context.Tasks
            .Where(t => t.AssignedUserId == userId)
            .ToListAsync();

    // 🔵 Méthode complète avec navigation
    public async Task<TaskItemEntity?> GetWithDetailsByIdAsync(Guid id) =>
        await context.Tasks
            .Include(t => t.Project)
            .Include(t => t.AssignedUser)
            .FirstOrDefaultAsync(t => t.Id == id);

    // Commandes
    public async Task AddAsync(TaskItemEntity task)
    {
        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItemEntity task)
    {
        context.Tasks.Update(task);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskItemEntity task)
    {
        context.Tasks.Remove(task);
        await context.SaveChangesAsync();
    }
}