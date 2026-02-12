using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Application.Commands.Usuarios;
using Veiculos.Application.Queries.Usuarios;

namespace Veiculos.WebApi.Controllers;

[ApiController]
[Route("api/usuarios")]
[Authorize]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(AdicionarUsuarioCommand command)
    {
        var usuario = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var usuario = await _mediator.Send(new ObterUsuarioPorIdQuery(id));

        if (usuario is null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var usuarios = await _mediator.Send(new ListarUsuariosQuery());
        return Ok(usuarios);
    }

}