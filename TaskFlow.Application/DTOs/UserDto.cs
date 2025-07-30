using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    
    public string Username { get; set; } = default!;
    
    public string Email { get; set; } = default!;
    
    public string PasswordHash { get; set; } = default!;
    
    public UserRole Role { get; set; }
}