using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class PerfilService(ApiContext apiContext) : IPerfilService
    {
        private readonly ApiContext _apiContext = apiContext;
        public async Task<IEnumerable<Perfil>> Obter(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                return await _apiContext.Perfis.ToListAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Perfil> ObterPorId(uint id, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                return await _apiContext.Perfis
                    .Where(p => p.Id == id).SingleOrDefaultAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
