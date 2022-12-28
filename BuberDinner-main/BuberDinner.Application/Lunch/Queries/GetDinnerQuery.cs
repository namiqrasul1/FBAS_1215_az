using BuberDinner.Application.Lunch.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Lunch.Queries;

public record GetDinnerQuery(Guid Id) : IRequest<ErrorOr<DinnerResult>>;