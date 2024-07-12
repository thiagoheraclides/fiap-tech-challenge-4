using Br.Com.Fiap.Api.DTO;
using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("pedido")]
    public class PedidoController(IPedidoService pedidoService) : ControllerBase
    {
        private readonly IPedidoService _pedidoService = pedidoService;

        [Authorize(Roles = "Administrador, Investidor, Consultor")]
        [HttpPost()]
        public async Task<IActionResult> Inserir(PedidoDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var pedido = new Pedido
                {
                    PrevidenciaId = dto.PrevidenciaId,
                    ConsorcioId = dto.ConsorcioId,
                    UsuarioId = dto.UsuarioId,                   
                    DataContratacao = dto.DataContratacao,
                };

                await _pedidoService.Inserir(pedido, cancellationToken);

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

                var pedidos = await _pedidoService.Obter(cancellationToken);
                var resposta = new { resultado = "Sucesso", pedidos };
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

                var consorcio = await _pedidoService.ObterPorId(id, cancellationToken);
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
