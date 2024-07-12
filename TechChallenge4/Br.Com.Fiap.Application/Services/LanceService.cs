using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class LanceService(ApiContext apiContext) : ILanceService
    {
        private readonly ApiContext _apiContext = apiContext;
        public async Task Inserir(Lance lance, CancellationToken cancellationToken)
        {
            try
            {
                var pedidos = await _apiContext.Pedidos
                               .Where(p => p.UsuarioId == lance.UsuarioId)
                               .ToListAsync(cancellationToken);

                int?[] identificadores = pedidos.Select(p => p.ConsorcioId).ToArray();

                if (identificadores.Length == 0)
                    throw new Exception("Consorcios não encontrados para este critério de pesquisa.");

                var consorcios = await _apiContext.Consorcios
                                                  .Where(c => identificadores.Contains(c.Id))
                                                  .ToListAsync(cancellationToken);

                var consorcio = consorcios.Where(c => c.Id == lance.ConsorcioId)
                                          .SingleOrDefault()
                                          ?? throw new Exception("Consorcio não encontrado!");

                var usuario = await _apiContext.Usuarios
                                               .Where(u => u.Id == lance.UsuarioId)
                                               .SingleOrDefaultAsync(cancellationToken)
                                               ?? throw new Exception("Usuario não encontrado!");

                if (consorcio != null)
                    lance.Consorcio = consorcio;

                lance.Usuario = usuario;

                await _apiContext.Lances.AddAsync(lance, cancellationToken);
                await _apiContext.SaveChangesAsync(cancellationToken);
               
            }
            catch (Exception)
            {

                throw;
            }
        }

 

        public async Task<IEnumerable<Lance>> Obter(CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Lances
                                        .ToListAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Lance> ObterPorId(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Lances
                                        .Where(p => p.Id == id)
                                        .SingleOrDefaultAsync(cancellationToken)
                                        ?? throw new Exception("Lance não encontrado!");


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
