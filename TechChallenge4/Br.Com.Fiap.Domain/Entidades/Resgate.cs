using System.Text.Json.Serialization;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Resgate
    {
        public int Id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int? PrevidenciaId { get; set; }

        public Previdencia? Previdencia { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public uint UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

    }
}
