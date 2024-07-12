using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Application.Interfaces
{
    public interface ITokenService
    {
        string GetToken(Usuario usuario);
    }
}
