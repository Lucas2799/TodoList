using TodoList.Domain.Enums;

namespace TodoList.Domain.Entities;

public class Sprint
{
    public Guid Id { get; private set; }

    public Guid ProjectId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public DateOnly StartDate { get; private set; }

    public DateOnly EndDate { get; private set; }

    public SprintStatus Status { get; private set; }

    public Project Project { get; private set; } = null!;

    private readonly List<TaskItem> _tasks = [];
    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

    protected Sprint()
    {
    }

    public Sprint(
        Guid projectId,
        string name,
        DateOnly startDate,
        DateOnly endDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Sprint name is required.", nameof(name));

        if (startDate > endDate)
            throw new ArgumentException("Start date cannot be greater than end date.");

        Id = Guid.NewGuid();
        ProjectId = projectId;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Status = SprintStatus.Planned;
    }

    public void Start()
    {
        if (Status != SprintStatus.Planned)
            throw new InvalidOperationException("Only planned sprints can be started.");

        Status = SprintStatus.Active;
    }

    public void Finish()
    {
        if (Status != SprintStatus.Active)
            throw new InvalidOperationException("Only active sprints can be completed.");

        Status = SprintStatus.Completed;
    }

    public void AddTask(TaskItem task)
    {
        if (task is null)
            throw new ArgumentNullException(nameof(task));

        _tasks.Add(task);
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Sprint name is required.", nameof(name));

        Name = name;
    }
}