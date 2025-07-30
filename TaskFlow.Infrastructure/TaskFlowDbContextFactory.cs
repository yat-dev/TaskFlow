using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
// using TaskFlow.Infrastructure.Persistence;

namespace TaskFlow.Infrastructure;

public class TaskFlowDbContextFactory : IDesignTimeDbContextFactory<TaskFlowDbContext>
{
    public TaskFlowDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // ← important !
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TaskFlowDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseNpgsql(connectionString);

        return new TaskFlowDbContext(optionsBuilder.Options);
    }
}