using Br.Com.Fiap.Domain.Entidades;

namespace Br.Com.Fiap.Api.DTO
{
    public class PagamentoDTO
    {

        public int? PrevidenciaId { get; set; }

        public int? ConsorcioId { get; set; }

        public uint UsuarioId { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public required decimal Valor { get; set; }

        public required decimal Multa { get; set; }

        public required decimal Juros { get; set; }

        public required decimal ValorTotal { get; set; }

    }
}
