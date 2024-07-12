using Br.Com.Fiap.Application.Interfaces;
using Br.Com.Fiap.Domain.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Br.Com.Fiap.Application.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;

        public string GetToken(Usuario usuario)
        {
            try
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var privateKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Symmetric:Key"]
                    ?? throw new ArgumentNullException("Jwt Symmetric Key"));

                var securityTokenDescritor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new(ClaimTypes.Name, usuario.Login),
                        new(ClaimTypes.Role, usuario.TipoUsuario.Nome)

                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = jwtTokenHandler.CreateToken(securityTokenDescritor);
                return jwtTokenHandler.WriteToken(token);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
