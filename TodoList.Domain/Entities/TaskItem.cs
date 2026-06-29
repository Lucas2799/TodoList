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
    private readonly List<Comment> _comments = [];
    public IReadOnlyCollection<Comment> Comments =>
        _comments.AsReadOnly();
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
    public void Unassign()
    {
        AssignedUserId = Guid.Empty;
        UpdatedAt = DateTime.UtcNow;
    }
    public void MoveToSprint(Guid? sprintId)
    {
        if (sprintId == Guid.Empty)
            throw new ArgumentException(
                "Sprint inválida.");
        SprintId = sprintId;
        UpdatedAt = DateTime.UtcNow;
    }
    public void AddComment(Comment comment)
    {
        if (comment is null)
            throw new ArgumentNullException(nameof(comment));

        _comments.Add(comment);
        UpdatedAt = DateTime.UtcNow;
    }
    public void MoveToProject(Guid projectid)
    {
        if(projectid == Guid.Empty)
            throw new ArgumentException(
                "Projeto inválido.");
        if(Status == Enums.TaskStatus.Done)
            throw new InvalidOperationException(
                "Não é possível mover uma tarefa concluída para outro projeto.");

        ProjectId = projectid;
        UpdatedAt = DateTime.UtcNow;
    }
    public void ChangeStatus(Enums.TaskStatus status)
    {
        if (Status == status)
            return;

        Status = status;

        UpdatedAt = DateTime.UtcNow;

        if (status == Enums.TaskStatus.Done)
            CompletedAt = DateTime.UtcNow;
        else
            CompletedAt = null;
    }
    public void ChangePriority(TaskPriority priority)
    {
        Priority = priority;
        UpdatedAt = DateTime.UtcNow;
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