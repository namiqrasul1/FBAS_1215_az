using System.Net;
using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => (serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (HttpStatusCode.InternalServerError, "Internal Server Error")
        };

        return Problem(detail: message, statusCode: (int)statusCode);
    }
}