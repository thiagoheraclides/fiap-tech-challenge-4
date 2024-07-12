using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface IUserService
    {
        Task<uint> Cadastrar(Usuario usuario);

        Task<Usuario?> FindByUsernameAndPassword(string username, string password);

        Task<IEnumerable<Usuario>> GetUsers();
    }
}
