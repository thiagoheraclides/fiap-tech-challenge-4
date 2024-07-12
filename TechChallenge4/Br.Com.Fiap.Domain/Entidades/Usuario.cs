using System.Text.Json.Serialization;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Usuario
    {
        public uint Id { get; set; }

        public string? Cpf { get; set; } = null!;

        public required string Nome { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public required string Login { get; set; } = null!;
        
        public required string Senha { get; set; } = null!;

        public DateTime? DataNascimento { get; set; }

        public DateTime UltimoAcesso { get; set; }



        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public uint? PerfilId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual Perfil? Perfil { get; set; }

        
        public uint? TipoUsuarioId { get; set; }
        
        public virtual TipoUsuario? TipoUsuario { get; set; }
        


        public virtual Endereco? Endereco { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<Pedido>? Pedidos { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<Lance>? Lances { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<Resgate>? Resgates { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ICollection<Pagamento>? Pagamentos { get; set; }

        public void Atualizar (Usuario novoUsuario)
        {
            try
            {
                Cpf = novoUsuario.Cpf;
                Nome = novoUsuario.Nome;
                Email = novoUsuario.Email;
                Perfil = novoUsuario.Perfil;
                TipoUsuario = novoUsuario.TipoUsuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AdicionarTipoUsuario(TipoUsuario tipoUsuario)
        {
            TipoUsuario = tipoUsuario;
        }

        public void AdicionarPerfil(Perfil perfil)
        {
            Perfil = perfil;
        }
    }
}
