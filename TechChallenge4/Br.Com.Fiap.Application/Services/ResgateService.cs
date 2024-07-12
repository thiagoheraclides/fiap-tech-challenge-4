using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class ResgateService(ApiContext apiContext) : IResgateService
    {
        private readonly ApiContext _apiContext = apiContext;
        public async Task Inserir(Resgate resgate, CancellationToken cancellationToken)
        {
            try
            {
                var previdencia = await _apiContext.Previdencias
                                                 .Where(c => c.Id == resgate.PrevidenciaId)
                                                 .SingleOrDefaultAsync(cancellationToken)
                                                 ?? throw new Exception("Previdência não encontrado!");

                var usuario = await _apiContext.Usuarios
                                               .Where(u => u.Id == resgate.UsuarioId)
                                               .SingleOrDefaultAsync(cancellationToken)
                                               ?? throw new Exception("Usuario não encontrado!");

                var pagamentos = await _apiContext.Pagamentos
                                                .Where(p => p.PrevidenciaId == resgate.PrevidenciaId && p.UsuarioId == resgate.UsuarioId)
                                                .ToListAsync(cancellationToken);

                var resgates = await _apiContext.Resgates
                                                .Where(r => r.PrevidenciaId == resgate.PrevidenciaId && r.UsuarioId == resgate.UsuarioId)
                                                .ToListAsync(cancellationToken);

                if (pagamentos.Count == 0)
                    throw new Exception("Não é possível efetuar operação de resgate desta previdência.");

                var valorTotalAcumulado = pagamentos.Sum(p => p.Valor);

                var valorTotalResgatado = resgates.Sum(r => r.Valor);

                if (resgate.Valor > (valorTotalAcumulado - valorTotalResgatado))
                    throw new Exception("Não é possível efetuar operação de resgate desta previdência.");

                if (previdencia != null)
                    resgate.Previdencia = previdencia;

                resgate.Usuario = usuario;

                await _apiContext.Resgates.AddAsync(resgate, cancellationToken);
                await _apiContext.SaveChangesAsync(cancellationToken);
               
            }
            catch (Exception)
            {

                throw;
            }
        }
 

        public async Task<IEnumerable<Resgate>> Obter(CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Resgates
                                        .ToListAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Resgate> ObterPorId(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _apiContext.Resgates
                                        .Where(p => p.Id == id)
                                        .SingleOrDefaultAsync(cancellationToken)
                                        ?? throw new Exception("Resgate não encontrado!");


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
