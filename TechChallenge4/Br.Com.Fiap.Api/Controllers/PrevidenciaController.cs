using Br.Com.Fiap.Api.DTO;
using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("previdencia")]
    public class PrevidenciaController(IPrevidenciaService previdenciaService) : ControllerBase
    {

        private readonly IPrevidenciaService _previdenciaService = previdenciaService;


        [Authorize(Roles = "Administrador")]
        [HttpPost()]
        public async Task<IActionResult> Inserir(PrevidenciaDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var previdencia = new Previdencia
                {
                    Tipo = dto.Tipo,
                    Inicio = dto.Inicio,
                    Termino = dto.Termino,
                    Retorno = dto.Retorno,
                    Parcela = dto.Parcela,
                    Tributacao = dto.Tributacao,
                    TaxaAdministracao = dto.TaxaAdministracao,
                    Observacao = dto.Observacao,
                    Modalidade = dto.Modalidade,
                    Rentabilidade = dto.Rentabilidade,
                    ValorAcumulado = dto.ValorAcumulado
                };

                await _previdenciaService.Inserir(previdencia, cancellationToken);

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

                var previdencias = await _previdenciaService.Obter(cancellationToken);
                var resposta = new { resultado = "Sucesso", previdencias };
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

                var previdencia = await _previdenciaService.ObterPorId(id, cancellationToken);
                return Ok(new { resultado = "Sucesso", previdencia });
            }
            catch (Exception exception)
            {
                var error = new { resultado = "Erro", mensagem = exception.Message };
                return BadRequest(error);
            }
        }
    }
}
