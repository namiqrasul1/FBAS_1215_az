using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Lunch.Commands.Delete;

public record DeleteDinnerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;