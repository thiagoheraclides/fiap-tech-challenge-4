using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface ITipoUsuarioService
    {
        Task<IEnumerable<TipoUsuario>> Obter(CancellationToken cancellationToken);

        Task<TipoUsuario> ObterPorId(uint id, CancellationToken cancellationToken);
    }
}
