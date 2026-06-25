using TodoList.Domain.Entities;

namespace TodoList.Application.Abstractions.Persistence;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Project>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Project>> GetByWorkspaceIdAsync(
        Guid workspaceId,
        CancellationToken cancellationToken = default);
    Task AddAsync(
        Project project,
        CancellationToken cancellationToken = default);
    void Update(Project project);
    void Delete(Project project);
}