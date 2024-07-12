using Br.Com.Fiap.Api.DTO;
using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("pagamento")]
    public class PagamentoController(IPagamentoService pagamentoService) : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService = pagamentoService;

        [Authorize(Roles = "Administrador, Investidor, Consultor")]
        [HttpPost()]
        public async Task<IActionResult> Inserir(PagamentoDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var pagamento = new Pagamento
                {
                    PrevidenciaId = dto.PrevidenciaId,
                    ConsorcioId = dto.ConsorcioId,
                    UsuarioId = dto.UsuarioId,
                    DataVencimento = dto.DataVencimento,
                    DataPagamento = dto.DataPagamento,
                    Valor = dto.Valor,
                    Multa = dto.Multa,
                    Juros = dto.Juros,
                    ValorTotal = dto.Valor + dto.Multa + dto.Juros
                };

                await _pagamentoService.Inserir(pagamento, cancellationToken);

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

                var pagamentos = await _pagamentoService.Obter(cancellationToken);
                var resposta = new { resultado = "Sucesso", pagamentos };
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
        public async Task<IActionResult> ObterPorId(ulong id, CancellationToken cancellationToken)
        {
            try
            {

                var pagamento = await _pagamentoService.ObterPorId(id, cancellationToken);
                return Ok(new { resultado = "Sucesso", pagamento });
            }
            catch (Exception exception)
            {
                var error = new { resultado = "Erro", mensagem = exception.Message };
                return BadRequest(error);
            }
        }
    }
}
