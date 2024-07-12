using System.Text.Json.Serialization;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Lance
    {
        public int Id { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int? ConsorcioId { get; set; }

        public Consorcio? Consorcio { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public uint UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }
    }
}
