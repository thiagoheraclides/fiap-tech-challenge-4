using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface IConsorcioService
    {      

        Task Inserir(Consorcio consorcio, CancellationToken cancellationToken);        

        Task<IEnumerable<Consorcio>> Obter(CancellationToken cancellationToken);        

        Task<Consorcio> ObterPorId(uint id, CancellationToken cancellationToken);

        Task<IEnumerable<Consorcio>> ObterPorUsuarioId(int id, CancellationToken cancellationToken);

    }
}
