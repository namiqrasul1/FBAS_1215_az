using BuberDinner.Application.Lunch.Commands.Create;
using BuberDinner.Application.Lunch.Commands.Delete;
using BuberDinner.Application.Lunch.Commands.Upsert;
using BuberDinner.Application.Lunch.Queries;
using BuberDinner.Contracts.Breakfast;
using BuberDinner.Contracts.Dinner;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("dinners")]
public class DinnersController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public DinnersController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDinnerRequest request)
    {
        var createDinnerCommand = _mapper.Map<CreateDinnerCommand>(request);

        var result = await _mediator.Send(createDinnerCommand);

        return result.Match<IActionResult>(
            _ => Ok(result.Value),
            failure => BadRequest(failure));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var getDinnerQuery = new GetDinnerQuery(id);

        var result = await _mediator.Send(getDinnerQuery);

        return result.Match(
            onValue: dinner => Ok(_mapper.Map<DinnerResponse>(dinner.Dinner)),
            errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpsertDinnerRequest request)
    {
        var updateDinnerCommand = _mapper.Map<UpsertDinnerCommand>(request);

        var result = await _mediator.Send(updateDinnerCommand);

        return result.Match(
            onValue: breakfast => Ok(_mapper.Map<DinnerResponse>(breakfast)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteBreakfastCommand = new DeleteDinnerCommand(id);

        var result = await _mediator.Send(deleteBreakfastCommand);

        return result.Match(
            onValue: breakfast => Ok(_mapper.Map<DinnerResponse>(breakfast)),
            errors => Problem(errors));
    }
}