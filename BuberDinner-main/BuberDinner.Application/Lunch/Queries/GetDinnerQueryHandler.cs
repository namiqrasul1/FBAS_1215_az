using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Lunch.Common;
using ErrorOr;
using MediatR;
using static BuberDinner.Domain.Common.Errors.Errors;

namespace BuberDinner.Application.Lunch.Queries;

public class GetDinnerQueryHandler : IRequestHandler<GetDinnerQuery, ErrorOr<DinnerResult>>
{
    private readonly IDinnerRepository _dinnerRepository;

    public GetDinnerQueryHandler(IDinnerRepository dinnerRepository)
    {
        _dinnerRepository = dinnerRepository;
    }

    public async Task<ErrorOr<DinnerResult>> Handle(GetDinnerQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var dinner = _dinnerRepository.GetDinnerById(request.Id);

        return dinner is null
            ? Dinner.NotFound
            : new DinnerResult(dinner);
    }
}