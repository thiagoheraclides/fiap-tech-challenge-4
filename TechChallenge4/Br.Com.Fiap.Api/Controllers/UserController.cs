using Br.Com.Fiap.Api.DTO;
using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Api.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UserController(IUserService userService, IConsorcioService consorcioService, IPrevidenciaService previdenciaService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IConsorcioService _consorcioService = consorcioService;
        private readonly IPrevidenciaService _previdenciaService = previdenciaService;        

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = new Usuario
                {
                    Cpf = usuarioDTO.CPF,
                    Nome = usuarioDTO.Nome,
                    Email = usuarioDTO.Email,
                    Login = usuarioDTO.Login,
                    Senha = usuarioDTO.Senha,
                    TipoUsuarioId = usuarioDTO.TipoUsuarioCodigo,
                    PerfilId = usuarioDTO.PerfilCodigo
                };

                var id = await _userService.Cadastrar(usuario);
                return Ok(new { UsuarioCodigo = id});
            }
            catch (Exception exception)
            {

                return BadRequest($"{exception.Message}");
            }
        }

        [Authorize(Roles = "Administrador, Investidor, Consultor")]
        [HttpGet("produtos/{id}")]
        public async Task<IActionResult> ObterProdutosPorUsuarioId(int id, CancellationToken cancellationToken)
        {
            try
            {
                var consorcios = await _consorcioService.ObterPorUsuarioId(id, cancellationToken);

                var listaConsorcio = consorcios
                    .Select(c => new ConsorcioDTO
                    {
                        Inicio = c.Inicio,
                        Observacao = c.Observacao,
                        Parcela = c.Parcela,
                        Prazo = c.Prazo,
                        Premio = c.Premio,
                        TaxaAdministracao = c.TaxaAdministracao,
                        Termino = c.Termino,
                        Tipo = c.Tipo,
                    });

                var previdencias = await _previdenciaService.ObterPorUsuarioId(id, cancellationToken);

                var listaPrevidencia = previdencias
                    .Select(c => new PrevidenciaDTO
                    {
                        Inicio = c.Inicio,
                        Observacao = c.Observacao,
                        Parcela = c.Parcela,
                        TaxaAdministracao = c.TaxaAdministracao,
                        Termino = c.Termino,
                        Tipo = c.Tipo,
                        Modalidade = c.Modalidade,
                        Rentabilidade = c.Rentabilidade,
                        Retorno = c.Retorno,
                        Tributacao = c.Tributacao,
                        ValorAcumulado = c.ValorAcumulado
                    });


                return Ok(new { Resultado = "Sucesso", Produtos = new ProdutosDTO { Consorcios = listaConsorcio, Previdencias = listaPrevidencia } });
            }
            catch (Exception exception)
            {

                return BadRequest($"{exception.Message}");
            }
        }
    }
}
