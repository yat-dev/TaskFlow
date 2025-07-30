using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure;

public class TaskFlowDbContext : DbContext
{
    public TaskFlowDbContext()
    {
    }
    
    public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options) : base(options)
    {
    }
    
    public DbSet<ProjectEntity> Projects => Set<ProjectEntity>();
    public DbSet<TaskItemEntity> Tasks => Set<TaskItemEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();

    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskFlowDbContext).Assembly);
    }
}