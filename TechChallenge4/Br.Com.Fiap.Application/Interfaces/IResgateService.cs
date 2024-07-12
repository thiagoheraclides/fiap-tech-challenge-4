using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface IResgateService
    {       

        Task Inserir(Resgate resgate, CancellationToken cancellationToken);

        Task<IEnumerable<Resgate>> Obter(CancellationToken cancellationToken);

        Task<Resgate> ObterPorId(int id, CancellationToken cancellationToken);

    }
}
