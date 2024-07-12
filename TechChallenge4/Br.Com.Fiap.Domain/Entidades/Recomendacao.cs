using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.Fiap.Domain.Entidades
{
    public class Recomendacao
    {
        public ulong Id { get; set; }

        public decimal Valor { get; set; } = default;

        public uint Quantidade { get; set; } = default;

        public DateTime Data { get; set; }

        public uint RentabilidadeEmDias { get; set; }

        public string Observacao { get; set; } = null!;

        public uint UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }

        public uint ConsultorId { get; set; }

        public virtual Usuario? Consultor { get; set; }

        public uint AtivoId { get; set; }

        public virtual Ativo? Ativo { get; set; }

    }
}
