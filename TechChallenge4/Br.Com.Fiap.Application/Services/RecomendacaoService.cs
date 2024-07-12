using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class RecomendacaoService(ApiContext apiContext) : IRecomendacaoService
    {
        private readonly ApiContext _apiContext = apiContext;

        //public async Task<IEnumerable<Recomendacao>> ObterRecomendacoesConsultor(uint id, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return await _apiContext.Recomendacoes
        //            .Where(p => p.ConsultorId == id)
        //            .ToListAsync(cancellationToken);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<IEnumerable<Recomendacao>> ObterRecomendacoesPorPerfilInvestidor(uint id, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return await _apiContext.Recomendacoes
        //            .Where(p => p.UsuarioId == id)
        //            .ToListAsync(cancellationToken);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<IEnumerable<Recomendacao>> ObterTodasRecomendacoes(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        return await _apiContext.Recomendacoes.ToListAsync(cancellationToken);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
