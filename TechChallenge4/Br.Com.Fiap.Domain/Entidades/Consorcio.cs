using System.Text.Json.Serialization;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Consorcio
    {
        public int Id { get; set; }

        public string? Tipo { get; set; }

        public DateTime? Inicio { get; set; }

        public DateTime? Termino { get; set; }

        public decimal Premio { get; set; }

        public decimal Parcela { get; set; }

        public int Prazo { get; set; }

        public decimal TaxaAdministracao { get; set; }

        public string? Observacao { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ICollection<Pedido>? Pedidos { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ICollection<Lance>? Lances { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ICollection<Pagamento>? Pagamentos { get; set; }

    }
}
