using TodoList.Domain.Entities;

namespace TodoList.Application.Abstractions.Persistence;

public interface ICommentRepository
{
    Task<Comment?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Comment>> GetByTaskIdAsync(
        Guid taskId,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Comment comment,
        CancellationToken cancellationToken = default);

    void Update(Comment comment);

    void Delete(Comment comment);
}