namespace Br.Com.Fiap.Domain.Entidades
{
    public class TipoUsuario
    {
        public uint Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public bool Status { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;


        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
