namespace Br.Com.Fiap.Api.DTO
{
    public class PrevidenciaDTO
    {
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
    }
}
