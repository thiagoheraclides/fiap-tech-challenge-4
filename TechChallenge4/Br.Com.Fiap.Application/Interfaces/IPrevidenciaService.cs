using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface IPrevidenciaService
    {       

        Task Inserir(Previdencia previdencia, CancellationToken cancellationToken);

        Task<IEnumerable<Previdencia>> Obter(CancellationToken cancellationToken);

        Task<Previdencia> ObterPorId(uint id, CancellationToken cancellationToken);

        Task<IEnumerable<Previdencia>> ObterPorUsuarioId(int id, CancellationToken cancellationToken);
    }
}
