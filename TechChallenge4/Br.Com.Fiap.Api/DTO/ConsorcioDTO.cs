namespace Br.Com.Fiap.Api.DTO
{
    public class ConsorcioDTO
    {
        public string? Tipo { get; set; }

        public DateTime? Inicio { get; set; }

        public DateTime? Termino { get; set; }

        public decimal Premio { get; set; }

        public decimal Parcela { get; set; }

        public int Prazo { get; set; }

        public decimal TaxaAdministracao { get; set; }

        public string? Observacao { get; set; }

    }
}
