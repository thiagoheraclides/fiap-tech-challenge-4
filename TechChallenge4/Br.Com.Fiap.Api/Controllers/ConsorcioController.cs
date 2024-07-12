using Br.Com.Fiap.Api.DTO;
using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("consorcio")]
    public class ConsorcioController(IConsorcioService consorcioService) : ControllerBase
    {
        private readonly IConsorcioService _consorcioService = consorcioService;

        [Authorize(Roles = "Administrador")]
        [HttpPost()]
        public async Task<IActionResult> Inserir(ConsorcioDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var consorcio = new Consorcio
                {
                    Tipo = dto.Tipo,
                    Inicio = dto.Inicio,
                    Termino = dto.Termino,
                    Premio = dto.Premio,
                    Parcela = dto.Parcela,
                    Prazo = dto.Prazo,
                    TaxaAdministracao = dto.TaxaAdministracao,
                    Observacao = dto.Observacao
                };

                await _consorcioService.Inserir(consorcio, cancellationToken);

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

                var consorcios = await _consorcioService.Obter(cancellationToken);
                var resposta = new { resultado = "Sucesso", consorcios };
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
        public async Task<IActionResult> ObterPorId(uint id, CancellationToken cancellationToken)
        {
            try
            {

                var consorcio = await _consorcioService.ObterPorId(id, cancellationToken);
                return Ok(new { resultado = "Sucesso", consorcio });
            }
            catch (Exception exception)
            {
                var error = new { resultado = "Erro", mensagem = exception.Message };
                return BadRequest(error);
            }
        }
    }
}
