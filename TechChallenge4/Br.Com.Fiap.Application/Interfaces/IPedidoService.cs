using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface IPedidoService
    {

        Task Inserir(Pedido pedido, CancellationToken cancellationToken);

        Task<IEnumerable<Pedido>> Obter(CancellationToken cancellationToken);

        Task<Pedido> ObterPorId(int id, CancellationToken cancellationToken);
    }
}
