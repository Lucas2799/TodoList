namespace TodoList.Domain.Entities;

public class Project
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;

    public Guid WorkspaceId { get; private set; }

    private readonly List<TaskItem> _tasks = [];
    public IReadOnlyCollection<TaskItem> Tasks => _tasks;

    protected Project() { }

    public Project(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
    }
}