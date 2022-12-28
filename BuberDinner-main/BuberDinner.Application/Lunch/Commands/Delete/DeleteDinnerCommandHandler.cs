using BuberDinner.Application.Common.Persistence;
using ErrorOr;
using MediatR;
using static BuberDinner.Domain.Common.Errors.Errors;

namespace BuberDinner.Application.Lunch.Commands.Delete;

public class DeleteDinnerCommandHandler : IRequestHandler<DeleteDinnerCommand, ErrorOr<Unit>>
{
    private readonly IDinnerRepository _dinnerRepository;

    public DeleteDinnerCommandHandler(IDinnerRepository DinnerRepository)
    {
        _dinnerRepository = DinnerRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteDinnerCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var dinner = _dinnerRepository.GetDinnerById(request.Id);

        if (dinner is null)
        {
            return Dinner.NotFound;
        }

        _dinnerRepository.DeleteDinner(dinner.Id);

        return Unit.Value;
    }
} 