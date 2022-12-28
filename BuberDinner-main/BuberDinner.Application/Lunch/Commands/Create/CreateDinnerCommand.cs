using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Lunch.Commands.Create;

public record CreateDinnerCommand(
     string Name,
     string Description,
     DateTime StartDateTime,
     DateTime EndDateTime,
     List<string> Savory,
     List<string> Sweet) : IRequest<ErrorOr<Guid>>;