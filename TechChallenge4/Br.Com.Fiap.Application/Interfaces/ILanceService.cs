using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface ILanceService
    {       

        Task Inserir(Lance lance, CancellationToken cancellationToken);

        Task<IEnumerable<Lance>> Obter(CancellationToken cancellationToken);

        Task<Lance> ObterPorId(int id, CancellationToken cancellationToken);

    }
}
