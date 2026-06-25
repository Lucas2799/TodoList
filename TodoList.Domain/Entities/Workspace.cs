namespace TodoList.Domain.Entities;
public class Workspace
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    private readonly List<Project> _projects = [];
    public IReadOnlyCollection<Project> Projects => _projects;

    private readonly List<User> _members = [];
    public IReadOnlyCollection<User> Members => _members;

    protected Workspace() { }

    public Workspace(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddMember(User user)
    {
        if (_members.Any(x => x.Id == user.Id))
            return;

        _members.Add(user);
    }

    public void AddProject(Project project)
    {
        _projects.Add(project);
    }
}