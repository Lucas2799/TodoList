using TodoList.Domain.Common;
using TodoList.Domain.Enums;
using TodoList.Domain.Validations;

namespace TodoList.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Enums.TaskStatus Status { get; private set; }
    public TaskPriority Priority { get; private set; }
    public Guid AssignedUserId { get; private set; }
    public Guid ProjectId { get; private set; }
    public Guid? SprintId { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    protected TaskItem() { }

    public TaskItem(
        string title,
        string description,
        TaskPriority priority,
        Guid projectId,
        Guid? sprintId)
    {

        TaskValidation.Validate(
            title, description, projectId);

        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        ProjectId = projectId;
        SprintId = sprintId;
        Priority = priority;
        Status = Enums.TaskStatus.Backlog;
        CreatedAt = DateTime.UtcNow;
    }

    public void AssignTo(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException(
                "Usuário inválido.");

        AssignedUserId = userId;
        UpdatedAt = DateTime.UtcNow;
    }
    public void ChangeStatus(Enums.TaskStatus status)
    {
        Status = status;

        UpdatedAt = DateTime.UtcNow;

        if (status == Enums.TaskStatus.Done)
            CompletedAt = DateTime.UtcNow;
        else
            CompletedAt = null;
    }
    public void Rename(
    string title,
    string description)
    {
        TaskValidation.Validate(
            title,
            description,
            ProjectId);

        Title = title;
        Description = description;

        UpdatedAt = DateTime.UtcNow;
    }
}