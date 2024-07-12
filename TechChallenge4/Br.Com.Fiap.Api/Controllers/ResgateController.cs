using Br.Com.Fiap.Api.DTO;
using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("resgate")]
    public class ResgateController(IResgateService resgateService) : ControllerBase
    {
        private readonly IResgateService _resgateService = resgateService;

        [Authorize(Roles = "Administrador, Investidor, Consultor")]
        [HttpPost()]
        public async Task<IActionResult> Inserir(ResgateDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var resgate = new Resgate
                {
                    PrevidenciaId = dto.PrevidenciaId,
                    UsuarioId = dto.UsuarioId,
                    Data = dto.Data,
                    Valor = dto.Valor
                };

                await _resgateService.Inserir(resgate, cancellationToken);

                return Created();

            }
            catch (Exception exception)
            {
                var error = new { resultado = "Erro", mensagem = exception.Message };
                return BadRequest(error);
            }
        }

        [Authorize(Roles = "Administrador, Investidor, Consultor")]
        [HttpGet()]
        public async Task<IActionResult> Obter(CancellationToken cancellationToken) 
        {
            try
            {

                var lances = await _resgateService.Obter(cancellationToken);
                var resposta = new { resultado = "Sucesso", lances };
                return Ok(resposta);
            }
            catch (Exception exception)
            {
                var error = new { resultado = "Erro", mensagem = exception.Message };
                return BadRequest(error);
            }
        }

        [Authorize(Roles = "Administrador, Investidor, Consultor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id, CancellationToken cancellationToken)
        {
            try
            {

                var lance = await _resgateService.ObterPorId(id, cancellationToken);
                return Ok(new { resultado = "Sucesso", lance });
            }
            catch (Exception exception)
            {
                var error = new { resultado = "Erro", mensagem = exception.Message };
                return BadRequest(error);
            }
        }
    }
}
