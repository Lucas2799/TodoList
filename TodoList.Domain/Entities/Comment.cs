namespace TodoList.Domain.Entities;

public class Comment
{
    public Guid Id { get; private set; }

    public Guid TaskItemId { get; private set; }

    public Guid UserId { get; private set; }

    public string Content { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    protected Comment() { }

    public Comment(
        Guid taskItemId,
        Guid userId,
        string content)
    {
        Id = Guid.NewGuid();
        TaskItemId = taskItemId;
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }
}   