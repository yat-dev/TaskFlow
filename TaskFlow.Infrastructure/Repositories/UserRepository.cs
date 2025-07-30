using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Infrastructure.Repositories;

public class UserRepository(TaskFlowDbContext context) : IUserRepository
{
    public async Task<UserEntity?> GetByIdAsync(Guid id) => await context.Users.FindAsync(id);

    public async Task<UserEntity?> GetByEmailAsync(string email) => await context.Users.FindAsync(email);

    public async Task<IEnumerable<UserEntity>> GetAllAsync() => await context.Users.ToListAsync();

    public async Task AddAsync(UserEntity userEntity)
    {
        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserEntity userEntity)
    {
        context.Users.Update(userEntity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(UserEntity userEntity)
    {
        context.Users.Remove(userEntity);
        await context.SaveChangesAsync();
    }
}