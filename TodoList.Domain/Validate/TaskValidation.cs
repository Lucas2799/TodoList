using TodoList.Domain.Entities;
using TodoList.Domain.Enums;

namespace TodoList.Domain.Validations;

public static class TaskValidation
{ 
    public static void Validate(
        string title,
        string description,
        Guid project)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "O título não pode estar vazio.",
                nameof(title));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException(
                "A descrição não pode estar vazia.",
                nameof(description));

        if(project == Guid.Empty)
            throw new ArgumentException(
                "O projeto não pode estar vazio.",
                nameof(project));
    } 

}