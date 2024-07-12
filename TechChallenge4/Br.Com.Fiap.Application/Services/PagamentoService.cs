using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class PagamentoService(ApiContext apiContext) : IPagamentoService
    {
        private readonly ApiContext _apiContext = apiContext;

        public async Task Inserir(Pagamento pagamento, CancellationToken cancellationToken)
        {
            try
            {
                var previdencia = await _apiContext.Previdencias
                                  .Where(p => p.Id == pagamento.PrevidenciaId)
                                  .SingleOrDefaultAsync(cancellationToken);

                var consorcio = await _apiContext.Consorcios
                                  .Where(c => c.Id == pagamento.ConsorcioId)
                                  .SingleOrDefaultAsync(cancellationToken);

                var usuario = await _apiContext.Usuarios
                                               .Where(u => u.Id == pagamento.UsuarioId)
                                               .SingleOrDefaultAsync(cancellationToken)
                                               ?? throw new Exception("Usuario não encontrado!");

                if (previdencia != null)
                {
                    pagamento.Previdencia = previdencia;

                    if (pagamento.Valor < previdencia.Parcela)
                        throw new Exception("O valor do pagamento é inferior ao valor da parcela.");
                }

                if (consorcio != null)
                {
                    pagamento.Consorcio = consorcio;

                    if (pagamento.Valor < consorcio.Parcela)
                        throw new Exception("O valor do pagamento é inferior ao valor da parcela.");
                }

                pagamento.Usuario = usuario;

                await _apiContext.Pagamentos.AddAsync(pagamento, cancellationToken);
                await _apiContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Pagamento>> Obter(CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Pagamentos
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

        public async Task<Pagamento> ObterPorId(ulong id, CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Pagamentos
                                        .Include(p => p.Previdencia)
                                        .Include(c => c.Consorcio)
                                        .Include(u => u.Usuario)
                                        .Where(p => p.Id == id)
                                        .SingleOrDefaultAsync(cancellationToken)
                                        ?? throw new Exception("Pagamento não encontrado!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
