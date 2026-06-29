using TodoList.Domain.Common;
using TodoList.Domain.Validations;

namespace TodoList.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Guid WorkspaceId { get; private set; }
    public bool IsDeleted { get; private set; }
    private readonly List<TaskItem> _tasks = [];
    public IReadOnlyCollection<TaskItem> Tasks => _tasks;
    private readonly List<Sprint> _sprints = [];
    public IReadOnlyCollection<Sprint> Sprints => _sprints.AsReadOnly();

    protected Project() { }

    public Project(string name, string description, Guid workspaceId)
    {
        ProjectValidation.Validate(
            name, description, workspaceId);

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        WorkspaceId = workspaceId;
    }

    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
        UpdatedAt = DateTime.UtcNow;
    }
    public void RemoveTask(TaskItem task)
    {
        _tasks.Remove(task);
        UpdatedAt = DateTime.UtcNow;
    }
    public void MoveToWorkspace(Guid workspaceId)
    {
        if (workspaceId == Guid.Empty)
            throw new ArgumentException(
                "Workspace inválido.",
                nameof(workspaceId));

        WorkspaceId = workspaceId;
        UpdatedAt = DateTime.UtcNow;
    }
    public void ChangeName(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }
    public void DeleteProject() 
    { 
        if(_tasks.Any())
            throw new InvalidOperationException(
                "Não é possível deletar um projeto com tarefas associadas.");
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
    public void AddSprint(Sprint sprint)
    {
         if (sprint == null)
            throw new ArgumentNullException(nameof(sprint), "Sprint não pode ser nulo.");

        _sprints.Add(sprint);
        UpdatedAt = DateTime.UtcNow;
    }

}