using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Lunch.Commands.Create;

public class CreateDinnerCommandHandler : IRequestHandler<CreateDinnerCommand, ErrorOr<Guid>>
{
    private readonly IDinnerRepository _dinnerRepository;

    public CreateDinnerCommandHandler(IDinnerRepository breakfastRepository)
    {
        _dinnerRepository = breakfastRepository;
    }

    public async Task<ErrorOr<Guid>> Handle(CreateDinnerCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var dinner = new Dinner(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        _dinnerRepository.CreateDinner(dinner);

        return dinner.Id;
    }
}