using Br.Com.Fiap.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("perfil")]
    public class PerfilController(IPerfilService perfilService) : ControllerBase
    {
        private readonly IPerfilService _perfilService = perfilService;

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Obter(CancellationToken cancellationToken)
        {
            try
            {
                var perfis = await _perfilService.Obter(cancellationToken);
                return Ok(perfis);
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
                var perfis = await _perfilService.ObterPorId(id, cancellationToken);
                return Ok(perfis);
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
        }
    }
}
