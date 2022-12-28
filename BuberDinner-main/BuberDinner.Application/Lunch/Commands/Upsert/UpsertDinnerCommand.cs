using BuberDinner.Application.Lunch.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Lunch.Commands.Upsert;

public record UpsertDinnerCommand(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet) : IRequest<ErrorOr<DinnerResult>>;