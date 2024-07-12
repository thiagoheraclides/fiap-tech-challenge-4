using System.Text.Json.Serialization;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int? PrevidenciaId { get; set; }

        public Previdencia? Previdencia { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int? ConsorcioId { get; set; }

        public Consorcio? Consorcio { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public uint UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public DateTime DataContratacao { get; set; }        

    }
}
