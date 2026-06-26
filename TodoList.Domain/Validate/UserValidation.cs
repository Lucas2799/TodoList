namespace TodoList.Domain.Validations;

public static class UserValidation
{
    public static void Validate(
        string firstName,
        string lastName,
        string email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException(
                "O primeiro nome não pode estar vazio.",
                nameof(firstName));

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException(
                "O sobrenome não pode estar vazio.",
                nameof(lastName));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException(
                "O e-mail não pode estar vazio.",
                nameof(email));

        if (!email.Contains('@'))
            throw new ArgumentException(
                "E-mail inválido.",
                nameof(email));
    }

    public static void ValidatePasswordHash(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException(
                "O hash da senha não pode estar vazio.",
                nameof(passwordHash));
    }
}