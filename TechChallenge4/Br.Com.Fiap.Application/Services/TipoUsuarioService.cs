using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class TipoUsuarioService(ApiContext apiContext) : ITipoUsuarioService
    {
        private readonly ApiContext _apiContext = apiContext;

        public async Task<IEnumerable<TipoUsuario>> Obter(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                return await _apiContext.TiposUsuarios.ToListAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TipoUsuario> ObterPorId(uint id, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                return await _apiContext.TiposUsuarios
                    .Where(p =>  p.Id == id).SingleOrDefaultAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
