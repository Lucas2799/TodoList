using TodoList.Domain.Enums;

namespace TodoList.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public Enums.TaskStatus Status { get; private set; }

    public TaskPriority Priority { get; private set; }

    public Guid AssignedUserId { get; private set; }

    public Guid ProjectId { get; private set; }

    public Guid? SprintId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? CompletedAt { get; private set; }

    protected TaskItem() { }

    public TaskItem(
        string title,
        string description,
        TaskPriority priority)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Priority = priority;

        Status = Enums.TaskStatus.Backlog;
        CreatedAt = DateTime.UtcNow;
    }

    public void AssignTo(Guid userId)
    {
        AssignedUserId = userId;
    }

    public void MoveToDoing()
    {
        Status = Enums.TaskStatus.Doing;
    }

    public void Complete()
    {
        Status = Enums.TaskStatus.Done;
        CompletedAt = DateTime.UtcNow;
    }
}