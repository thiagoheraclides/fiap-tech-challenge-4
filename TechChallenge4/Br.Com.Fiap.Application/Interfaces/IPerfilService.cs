using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface IPerfilService
    {
        Task<IEnumerable<Perfil>> Obter(CancellationToken cancellationToken);

        Task<Perfil> ObterPorId(uint id, CancellationToken cancellationToken);
    }
}
