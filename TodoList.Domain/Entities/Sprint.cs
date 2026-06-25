using TodoList.Domain.Enums;

namespace TodoList.Domain.Entities;

public class Sprint
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public DateOnly StartDate { get; private set; }

    public DateOnly EndDate { get; private set; }

    public SprintStatus Status { get; private set; }

    protected Sprint() { }

    public Sprint(
        string name,
        DateOnly startDate,
        DateOnly endDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Status = SprintStatus.Planned;
    }

    public void Start()
    {
        Status = SprintStatus.Active;
    }

    public void Finish()
    {
        Status = SprintStatus.Completed;
    }
}