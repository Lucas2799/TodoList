using TodoList.Domain.Entities;

namespace TodoList.Application.Abstractions.Persistence;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TaskItem>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TaskItem>> GetByProjectIdAsync(
        Guid projectId,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TaskItem>> GetByAssignedUserAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
    Task AddAsync(
        TaskItem task,
        CancellationToken cancellationToken = default);
    void Update(TaskItem task);
    void Delete(TaskItem task);
}