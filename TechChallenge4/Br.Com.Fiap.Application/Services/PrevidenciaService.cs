using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class PrevidenciaService(ApiContext apiContext) : IPrevidenciaService
    {
        private readonly ApiContext _apiContext = apiContext;

        public async Task Inserir(Previdencia previdencia, CancellationToken cancellationToken)
        {
            try
            {

                await _apiContext.Previdencias.AddAsync(previdencia, cancellationToken);
                await _apiContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Previdencia>> Obter(CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Previdencias                       
                                        .ToListAsync(cancellationToken)
                                        ?? throw new Exception("Previdência não encontrada!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Previdencia> ObterPorId(uint id, CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Previdencias
                                        .Where(p => p.Id == id)
                                        .SingleOrDefaultAsync(cancellationToken)
                                        ?? throw new Exception("Previdência não encontrada!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Previdencia>> ObterPorUsuarioId(int id, CancellationToken cancellationToken)
        {
            try
            {
                var pedidos = await _apiContext.Pedidos
                                               .Where(p => p.UsuarioId == id)
                                               .ToListAsync(cancellationToken);

                int?[] identificadores = pedidos.Select(p => p.PrevidenciaId).ToArray();

                if (identificadores.Length == 0)
                    throw new Exception("Previdências não encontradas para este critério de pesquisa.");

                var previdencias = await _apiContext.Previdencias
                                                    .Where(c => identificadores.Contains(c.Id))
                                                    .ToListAsync(cancellationToken);

                return previdencias;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
