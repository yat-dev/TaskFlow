using TaskFlow.Application.DTOs;
using TaskFlow.Application.Services.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Application.Services.Implementations;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);
        return user is null ? null : ToDto(user);
    }

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var user = await userRepository.GetByEmailAsync(email);
        return user is null ? null : ToDto(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await userRepository.GetAllAsync();
        return users.Select(ToDto);
    }

    public async Task<UserDto> CreateAsync(UserDto user)
    {
        var entity = new UserEntity()
        {
            Id = Guid.NewGuid(),
            Username = user.Username,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = user.Role
        };

        await userRepository.AddAsync(entity);
        return ToDto(entity);
    }

    public async Task UpdateAsync(UserDto user)
    {
        var entity = new UserEntity()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = user.Role
        };

        await userRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user != null)
            await userRepository.DeleteAsync(user);
    }

    private static UserDto ToDto(UserEntity user) => new()
    {
        Id = user.Id,
        Username = user.Username,
        Email = user.Email,
        PasswordHash = user.PasswordHash,
        Role = user.Role
    };
}
