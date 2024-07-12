using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Infra.Data
{
    public static class ContextInitializer
    {
        public static void Initialize(ApiContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if (!context.TiposUsuarios.Where(p => p.Nome == "Administrador").Any())
                {
                    var admin = new TipoUsuario { Nome = "Administrador", Descricao = "Usuário administrador", Status = true, CriadoEm = DateTime.UtcNow };
                    context.TiposUsuarios.Add(admin);

                    var consultor = new TipoUsuario { Nome = "Consultor", Descricao = "Usuário consultor", Status = true, CriadoEm = DateTime.UtcNow };
                    context.TiposUsuarios.Add(consultor);

                    var investidor = new TipoUsuario { Nome = "Investidor", Descricao = "Usuário investidor", Status = true, CriadoEm = DateTime.UtcNow };
                    context.TiposUsuarios.Add(investidor);

                    context.SaveChanges();

                    if (!context.Usuarios.Where(u => u.Nome == "api-admin").Any())
                    {
                        var apiAdmin = new Usuario
                        {
                            Cpf = "00000000000",
                            Nome = "api-admin",
                            Email = "admin@api-admin.com.br",
                            Login = "admin",
                            Senha = "admin",
                            UltimoAcesso = DateTime.UtcNow,
                            TipoUsuario = admin,
                        };

                        context.Usuarios.Add(apiAdmin);
                        context.SaveChanges();
                    }

                    if (!context.Usuarios.Where(u => u.Login == "gesner.zarabatana").Any())
                    {
                        var usuarioInvestidor = new Usuario
                        {
                            Cpf = "31525845589",
                            Nome = "Gesner Zarabatana",
                            Email = "gesner.zarabatana@email.com.br",
                            Login = "gesner.zarabatana",
                            Senha = "123456",
                            UltimoAcesso = DateTime.UtcNow,
                            TipoUsuario = investidor,
                            Endereco = new Endereco
                            {
                                Cep = "0927599",
                                Logradouro = "Rua Liguaria",
                                Numero = "215",
                                Complemento = "Casa 1",
                                Bairro = "Parque Castelo",
                                Cidade = "Mauá",
                                Estado = "SP"
                            }
                        };

                        context.Usuarios.Add(usuarioInvestidor);
                        context.SaveChanges();
                    }
                }

                if (!context.Perfis.Any())
                {
                    var conservador = new Perfil { Nome = "Investidor", Descricao = "Perfil conservador", Status = true, CriadoEm = DateTime.UtcNow };
                    context.Perfis.Add(conservador);

                    var moderado = new Perfil { Nome = "Moderado", Descricao = "Perfil moderado", Status = true, CriadoEm = DateTime.UtcNow };
                    context.Perfis.Add(moderado);

                    var arrojado = new Perfil { Nome = "Arrojado", Descricao = "Perfil arrojado", Status = true, CriadoEm = DateTime.UtcNow };
                    context.Perfis.Add(arrojado);

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
