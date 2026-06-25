namespace TodoList.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    protected User() { }

    public User(
        string firstName,
        string lastName,
        string email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("O primeiro nome não pode estar vazio.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("O sobrenome não pode estar vazio.", nameof(lastName));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O email não pode estar vazio.", nameof(email));

        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public string FullName =>
        $"{FirstName} {LastName}";
}