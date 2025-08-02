using TaskFlow.Blazor.Models;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Blazor.Services;

public class TaskService(HttpClient httpClient)
{
    public async Task<List<TaskDto>> GetTasksAsync()
    {
        return await httpClient.GetFromJsonAsync<List<TaskDto>>($"api/tasks") ?? new List<TaskDto>();
    }
}