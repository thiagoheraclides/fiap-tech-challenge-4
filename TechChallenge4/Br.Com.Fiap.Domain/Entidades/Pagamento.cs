using System.Text.Json.Serialization;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Pagamento
    {
        public ulong Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int? PrevidenciaId { get; set; }

        public Previdencia? Previdencia { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public int? ConsorcioId { get; set; }

        public Consorcio? Consorcio { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public uint UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public required decimal Valor { get; set; }

        public required decimal Multa { get; set; } = 0;

        public required decimal Juros { get; set; } = 0;

        public required decimal ValorTotal { get; set; }

    }
}
