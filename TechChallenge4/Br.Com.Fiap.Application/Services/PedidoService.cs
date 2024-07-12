using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class PedidoService(ApiContext apiContext) : IPedidoService
    {
        private readonly ApiContext _apiContext = apiContext;

        public async Task Inserir(Pedido pedido, CancellationToken cancellationToken)
        {
            try
            {
                var previdencia = await _apiContext.Previdencias
                                                  .Where(p => p.Id == pedido.PrevidenciaId)
                                                  .SingleOrDefaultAsync(cancellationToken);

                var consorcio = await _apiContext.Consorcios
                                  .Where(c => c.Id == pedido.ConsorcioId)
                                  .SingleOrDefaultAsync(cancellationToken);

                var usuario = await _apiContext.Usuarios
                                               .Where(u => u.Id == pedido.UsuarioId)
                                               .SingleOrDefaultAsync(cancellationToken)
                                               ?? throw new Exception("Usuario não encontrado!");

                if (previdencia != null)
                    pedido.Previdencia = previdencia;

                if (consorcio != null)
                    pedido.Consorcio = consorcio;

                pedido.Usuario = usuario;

                await _apiContext.Pedidos.AddAsync(pedido, cancellationToken);
                await _apiContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Pedido>> Obter(CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Pedidos
                                        .Include(p => p.Previdencia)
                                        .Include(c => c.Consorcio)
                                        .Include(u => u.Usuario)
                                        .ToListAsync(cancellationToken);
                                    
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Pedido> ObterPorId(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Pedidos
                                        .Include(p => p.Previdencia)
                                        .Include(c => c.Consorcio)
                                        .Include(u => u.Usuario)
                                        .Where(p => p.Id == id)
                                        .SingleOrDefaultAsync(cancellationToken)
                                        ?? throw new Exception("Pedido não encontrado!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
