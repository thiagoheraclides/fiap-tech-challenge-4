using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class ConsorcioService(ApiContext apiContext) : IConsorcioService
    {
        private readonly ApiContext _apiContext = apiContext;

        public async Task Inserir(Consorcio consorcio, CancellationToken cancellationToken)
        {
            try
            {

                await _apiContext.Consorcios.AddAsync(consorcio, cancellationToken);
                await _apiContext.SaveChangesAsync(cancellationToken);
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Consorcio>> Obter(CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Consorcios
                    .ToListAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Consorcio> ObterPorId(uint id, CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Consorcios
                                        .Where(p => p.Id == id)
                                        .SingleOrDefaultAsync(cancellationToken)
                                        ?? throw new Exception("Consorcio não encontrado!");


            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<Consorcio>> ObterPorUsuarioId(int id, CancellationToken cancellationToken)
        {
            try
            {
                var pedidos = await _apiContext.Pedidos
                                               .Where(p => p.UsuarioId == id)
                                               .ToListAsync (cancellationToken);

                int?[] identificadores = pedidos.Select(p =>p.ConsorcioId).ToArray();

                if (identificadores.Length == 0)
                    throw new Exception("Consorcios não encontrados para este critério de pesquisa.");

                var consorcios = await _apiContext.Consorcios
                                                  .Where(c => identificadores.Contains(c.Id))
                                                  .ToListAsync (cancellationToken);

                return consorcios;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
