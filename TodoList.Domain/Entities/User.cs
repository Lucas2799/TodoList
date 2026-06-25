namespace TodoList.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; } = string.Empty;

    protected User(){}

    public User(
        string firstName,
        string lastName,
        string email,
        string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("O primeiro nome não pode estar vazio.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("O sobrenome não pode estar vazio.", nameof(lastName));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O email não pode estar vazio.", nameof(email));
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException(
                "O hash da senha não pode estar vazio.", nameof(passwordHash));

        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public void ChangePassword(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException(
                "O hash da senha não pode estar vazio.", nameof(passwordHash));

        PasswordHash = passwordHash;
    }

    public string FullName =>
        $"{FirstName} {LastName}";
}