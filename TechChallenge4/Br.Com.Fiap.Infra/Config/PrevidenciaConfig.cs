using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class PrevidenciaConfig : IEntityTypeConfiguration<Previdencia>
    {
        public void Configure(EntityTypeBuilder<Previdencia> builder)
        {
            builder.ToTable("TB_PREVIDENCIA");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_PREVIDENCIA");

            builder.Property(p => p.Id)
                .HasColumnName("CD_PREVIDENCIA")                
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

            builder.Property(p => p.Retorno)
                .HasColumnName("VL_RETORNO")
                .HasPrecision(8,2)
                .IsRequired();

            builder.Property(p => p.Parcela)
                .HasColumnName("VL_PARCELA")
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(p => p.Tributacao)
                .HasColumnName("DS_TRIBUTACAO")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.TaxaAdministracao)
                .HasColumnName("VL_TAXA_ADMINISTRACAO")
                .HasPrecision(8,2)
                .IsRequired();

            builder.Property(p => p.Observacao)
                .HasColumnName("TX_OBSERVACAO")
                .IsRequired(false);

            builder.Property(p => p.Modalidade)
                .HasColumnName("DS_MODALIDADE")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Rentabilidade)
                .HasColumnName("VL_RENTABILIDADE")
                .HasPrecision(8,2)
                .IsRequired();

            builder.Property(p => p.ValorAcumulado)
                .HasColumnName("VL_ACUMULADO")
                .HasPrecision(8,2)
                .IsRequired();
        }
    }
}
