using TodoList.Domain.Entities;
using TodoList.Domain.Entities.Workspace;

namespace TodoList.Application.Abstractions.Persistence;

public interface IWorkspaceRepository
{
    Task<Workspace?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Workspace>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task AddAsync(
        Workspace workspace,
        CancellationToken cancellationToken = default);
    void Update(Workspace workspace);
    void Delete(Workspace workspace);
}