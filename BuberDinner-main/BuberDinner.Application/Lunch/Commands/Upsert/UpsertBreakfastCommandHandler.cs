using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Lunch.Common;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Lunch.Commands.Upsert;

public class UpsertDinnerCommandHandler : IRequestHandler<UpsertDinnerCommand, ErrorOr<DinnerResult>>
{
    private readonly IDinnerRepository _dinnerRepository;

    public UpsertDinnerCommandHandler(IDinnerRepository dinnerRepository)
    {
        _dinnerRepository = dinnerRepository;
    }

    public async Task<ErrorOr<DinnerResult>> Handle(UpsertDinnerCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var dinner = _dinnerRepository.GetDinnerById(request.Id);

        if (dinner is null)
        {
            dinner = new Dinner(
                request.Id,
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            _dinnerRepository.CreateDinner(dinner);
        }
        else
        {
            dinner.Update(
                request.Name,
                request.Description,
                request.StartDateTime,
                request.EndDateTime,
                request.Savory,
                request.Sweet);

            _dinnerRepository.UpsertDinner(dinner);
        }

        return new DinnerResult(dinner);
    }
}