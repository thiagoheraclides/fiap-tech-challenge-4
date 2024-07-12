using System.Text.Json.Serialization;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Perfil
    {
        public uint Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public bool Status { get; set; } = default;

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;


        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
