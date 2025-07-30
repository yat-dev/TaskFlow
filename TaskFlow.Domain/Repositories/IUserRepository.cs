using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(Guid id);
    Task<UserEntity?> GetByEmailAsync(string email);
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task AddAsync(UserEntity userEntity);
    Task UpdateAsync(UserEntity userEntity);
    Task DeleteAsync(UserEntity userEntity);
}