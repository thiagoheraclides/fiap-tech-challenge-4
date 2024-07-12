using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface IPagamentoService
    {
        Task Inserir(Pagamento pagamento, CancellationToken cancellationToken);

        Task<IEnumerable<Pagamento>> Obter(CancellationToken cancellationToken);

        Task<Pagamento> ObterPorId(ulong id, CancellationToken cancellationToken);
    }
}
