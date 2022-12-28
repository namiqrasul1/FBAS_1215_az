using Microsoft.AspNetCore.Mvc;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MediatR;
using BuberDinner.Application.Authentication.Commands.Login;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(
        ISender mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);

        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

       return registerResult.Match(
            onValue: authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var query = _mapper.Map<LoginQuery>(loginRequest);

        var authResult = await _mediator.Send(query);

        return authResult.Match(
            onValue: authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
            errors => Problem(errors));
    }
}