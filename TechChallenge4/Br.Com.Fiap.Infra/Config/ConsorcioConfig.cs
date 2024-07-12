using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class ConsorcioConfig : IEntityTypeConfiguration<Consorcio>
    {
        public void Configure(EntityTypeBuilder<Consorcio> builder)
        {
            builder.ToTable("TB_CONSORCIO");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_CONSORCIO");

            builder.Property(p => p.Id)
                .HasColumnName("CD_CONSORCIO")                
                .IsRequired();

            builder.Property(p => p.Tipo)
                .HasColumnName("DS_TIPO")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(p => p.Inicio)
                .HasColumnName("DTH_INICIO")
                .IsRequired();

            builder.Property(p => p.Termino)
                .HasColumnName("DTH_FIM")
                .IsRequired(false);

            builder.Property(p => p.Premio)
                .HasColumnName("VL_PREMIO")
                .HasPrecision(8,2)
                .IsRequired();

            builder.Property(p => p.Parcela)
                .HasColumnName("VL_PARCELA")
                .HasPrecision(8,2)
                .IsRequired();

            builder.Property(p => p.Prazo)
                .HasColumnName("NR_PRAZO")                
                .IsRequired();

            builder.Property(p => p.TaxaAdministracao)
                .HasColumnName("VL_TAXA_ADMINISTRACAO")
                .HasPrecision(8,2)
                .IsRequired();

            builder.Property(p => p.Observacao)
                .HasColumnName("TX_OBSERVACAO")
                .IsRequired(false);

        }
    }
}
