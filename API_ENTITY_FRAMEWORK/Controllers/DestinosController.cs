using API_ENTITY_FRAMEWORK.DTO.BancoDestinosDTOs;
using API_ENTITY_FRAMEWORK.Models.Banco_Destinos;
using API_ENTITY_FRAMEWORK.Services.Destino_Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_ENTITY_FRAMEWORK.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DestinosController : ControllerBase
{
    private readonly IDestinosServices _destinosServices;

    public DestinosController(IDestinosServices destinosServices)
    {
        _destinosServices = destinosServices;
    }

    [HttpGet("{externalKey}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Destino), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid externalKey)
    {
        var destino = await _destinosServices.GetDestinoAsync(externalKey)
            .ConfigureAwait(false);
        
        return Ok(destino);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(typeof(Destino), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] DestinoDTO destinoDTO)
    {
        var destino = new Destino(destinoDTO.LocalDestino, destinoDTO.Pais, destinoDTO.Cidade);

        await _destinosServices.AddAsync(destino)
            .ConfigureAwait(false);
        
        return Ok(destino);
    }
}
