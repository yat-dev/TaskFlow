using TaskFlow.Application.DTOs;

namespace TaskFlow.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(Guid id);
    
    Task<UserDto?> GetByEmailAsync(string email);
    
    Task<IEnumerable<UserDto>> GetAllAsync();
    
    Task<UserDto> CreateAsync(UserDto user);
    
    Task UpdateAsync(UserDto user);
    
    Task DeleteAsync(Guid id);
}