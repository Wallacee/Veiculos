using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Veiculos.Application.Commands.Veiculos;
using Veiculos.Application.Queries.Veiculos;

namespace Veiculos.WebApi.Controllers;

[ApiController]
[Route("api/veiculos")]
[Authorize]
public class VeiculosController : ControllerBase
{
    private readonly IMediator _mediator;

    public VeiculosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(AdicionarVeiculoCommand command)
    {
        var veiculo = await _mediator.Send(command);
        return Ok(veiculo);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, AtualizarVeiculoCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        await _mediator.Send(new ExcluirVeiculoCommand(id));
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Obter(Guid id)
    {
        var veiculo = await _mediator.Send(new ObterVeiculoPorIdQuery(id));
        
        if (veiculo is null)
            return NotFound();

        return Ok(veiculo);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var veiculos = await _mediator.Send(new ListarVeiculosQuery());
        return Ok(veiculos);
    }
}