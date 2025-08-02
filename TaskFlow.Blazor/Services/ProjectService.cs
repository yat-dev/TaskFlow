using TaskFlow.Blazor.Models;

namespace TaskFlow.Blazor.Services;

public class ProjectService(HttpClient client)
{
    public async Task<List<ProjectDto>> GetProjectsAsync()
    {
        var result = await client.GetFromJsonAsync<List<ProjectDto>>($"api/projects");

        return result ?? new List<ProjectDto>();
    }
}