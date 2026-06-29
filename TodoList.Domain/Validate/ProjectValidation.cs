using TodoList.Domain.Entities;
using TodoList.Domain.Enums;

namespace TodoList.Domain.Validations;

public static class ProjectValidation
{
    public static void Validate(
        string name,
        string description,
        Guid workspaceId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "O título não pode estar vazio.",
                nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException(
                "A descrição não pode estar vazia.",
                nameof(description));

        if (workspaceId == Guid.Empty)
            throw new ArgumentException(
                "O workspace não pode estar vazio.",
                nameof(workspaceId));
    }

}