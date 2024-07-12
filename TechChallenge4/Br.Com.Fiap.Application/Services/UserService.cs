using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Application.Services
{
    public class UserService(ApiContext apiContext) : IUserService
    {
		private readonly ApiContext _apiContext = apiContext;

        public async Task<uint> Cadastrar(Usuario usuario)
        {
			try
			{
				var tipoUsuario = await _apiContext.TiposUsuarios
					.Where(p => p.Id == usuario.TipoUsuarioId).FirstOrDefaultAsync()
					?? throw new Exception("Tipo de usuário informado não encontrado!");

				usuario.AdicionarTipoUsuario(tipoUsuario);

                var perfil = await _apiContext.Perfis
                    .Where(p => p.Id == usuario.PerfilId).FirstOrDefaultAsync();
					;
                if (perfil is not null)
                    usuario.AdicionarPerfil(perfil);

                var usuarioExistente = await _apiContext.Usuarios
					.Where(p => p.Login == usuario.Login).SingleOrDefaultAsync();

				if (usuarioExistente is null) 
				{
					_apiContext.Usuarios.Add(usuario);
				}
				else
				{
                    usuarioExistente.Atualizar(usuario);
				}

				_apiContext.SaveChanges();

				return (uint)usuario.Id;
            }
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<Usuario?> FindByUsernameAndPassword(string username, string password)
        {
			try
			{
                _apiContext.Database.EnsureCreated();
				return await _apiContext.Usuarios
                                        .Include(u => u.TipoUsuario)
                                        .FirstOrDefaultAsync(u => u.Login == username && u.Senha == password);
            }
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<IEnumerable<Usuario>> GetUsers()
        {
			try
			{
				_apiContext.Database.EnsureCreated();
				return await _apiContext.Usuarios.ToListAsync();
			}
			catch (Exception)
			{

				throw;
			}
        }


    }
}
