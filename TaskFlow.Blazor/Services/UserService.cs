using TaskFlow.Blazor.Models;

namespace TaskFlow.Blazor.Services;

public class UserService(HttpClient httpClient)
{
    public async Task<List<UserDto>> GetUsersAsync()
    {
        return await httpClient.GetFromJsonAsync<List<UserDto>>($"api/users") ?? new List<UserDto>();
    }
}