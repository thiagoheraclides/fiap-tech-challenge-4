using Br.Com.Fiap.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("tipo-usuario")]
    public class TipoUsuarioController(ITipoUsuarioService tipoUsuarioService) : ControllerBase
    {
        private readonly ITipoUsuarioService _tipoUsuarioService = tipoUsuarioService;

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Obter(CancellationToken cancellationToken)
        {
            try
            {
                var tiposUsuario = await _tipoUsuarioService.Obter(cancellationToken);

                // adaptação técnica para remover o objeto lazy loading da resposta;
                var resposta = JsonSerializer.Serialize(tiposUsuario);
                return Ok(resposta);
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(uint id, CancellationToken cancellationToken)
        {
            try
            {
                var tiposUsuario = await _tipoUsuarioService.ObterPorId(id, cancellationToken);

                // adaptação técnica para remover o objeto lazy loading da resposta;
                var resposta = JsonSerializer.Serialize(tiposUsuario);
                return Ok(resposta);
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
        }
    }
}
