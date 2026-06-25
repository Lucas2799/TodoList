using TodoList.Domain.Entities;

namespace TodoList.Application.Abstractions.Persistence;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<User>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task AddAsync(
        User user,
        CancellationToken cancellationToken = default);
    void Update(User user);
    void Delete(User user);
}