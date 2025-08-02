using TaskFlow.Blazor.Models;

namespace TaskFlow.Blazor.Services;

public class ProjectService(HttpClient httpClient)
{
    public async Task<List<ProjectDto>> GetProjectsAsync()
    {
        return await httpClient.GetFromJsonAsync<List<ProjectDto>>($"api/projects") ?? new List<ProjectDto>();
    }
}