using MediatR;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Application.Commands.Auth;

namespace Veiculos.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(new { access_token = token });
    }
}