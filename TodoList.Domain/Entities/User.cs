using TodoList.Domain.Common;
using TodoList.Domain.Validations;

namespace TodoList.Domain.Entities;

public class User : BaseEntity
{
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
        UserValidation.Validate(
            firstName, lastName, email);

        UserValidation.ValidatePasswordHash(passwordHash);

        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow; ;
    }

    public void ChangePassword(string passwordHash)
    {
        UserValidation.ValidatePasswordHash(passwordHash);

        PasswordHash = passwordHash;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateProfile(
        string firstName,
        string lastName,
        string email)
    {
        UserValidation.Validate(
           firstName, lastName, email);

        FirstName = firstName;
        LastName = lastName;
        Email = email;

        UpdatedAt = DateTime.UtcNow;
    }

    public string FullName =>
        $"{FirstName} {LastName}";
}