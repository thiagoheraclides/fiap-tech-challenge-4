using System.Text.Json.Serialization;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Previdencia
    {
        public int Id { get; set; }

        public string? Tipo { get; set; }

        public DateTime? Inicio { get; set; }

        public DateTime? Termino { get; set; }

        public decimal Retorno { get; set; }

        public decimal Parcela { get; set; }

        public string? Tributacao { get; set; }

        public decimal TaxaAdministracao { get; set; }

        public string? Observacao { get; set; }

        public string? Modalidade { get; set; }

        public decimal Rentabilidade { get; set; }

        public decimal ValorAcumulado { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ICollection<Pedido>? Pedidos { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ICollection<Resgate>? Resgates { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public ICollection<Pagamento>? Pagamentos { get; set; }
    }
}
