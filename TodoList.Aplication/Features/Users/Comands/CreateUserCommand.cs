using MediatR;

namespace TodoList.Aplication.Features.Users.Comands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email
    ):IRequest<Guid>;
