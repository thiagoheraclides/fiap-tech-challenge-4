using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class PagamentoConfig : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {

            builder.ToTable("TB_PAGAMENTO");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_PAGAMENTO");

            builder.Property(p => p.Id)
                .HasColumnName("CD_PAGAMENTO")
                .IsRequired();

            builder.Property(p => p.PrevidenciaId)
                .HasColumnName("CD_PREVIDENCIA_CONTRATADA")
                .IsRequired(false);

            builder.Property(p => p.ConsorcioId)
                .HasColumnName("CD_CONSORCIO_CONTRATADO")
                .IsRequired(false);

            builder.Property(p => p.UsuarioId)
                .HasColumnName("CD_CONTRATANTE")
                .IsRequired();

            builder.Property(p => p.DataVencimento)
                .HasColumnName("DTH_VENCIMENTO")
                .IsRequired();

            builder.Property(p => p.DataPagamento)
                .HasColumnName("DTH_PAGAMENTO")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VL_PAGAMENTO")
                .HasPrecision(8,2)
                .IsRequired();

            builder.Property(p => p.Multa)
                .HasColumnName("VL_MULTA")
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(p => p.Juros)
                .HasColumnName("VL_JUROS")
                .HasPrecision(8, 2)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .HasColumnName("VL_PAGAMENTO_TOTAL")
                .HasPrecision(8, 2)
                .IsRequired();

            builder
                .HasOne(p => p.Usuario)
                .WithMany(p => p.Pagamentos)
                .HasConstraintName("FK_USUARIO_PAGAMENTO")
                .HasForeignKey(p => p.UsuarioId)
                .IsRequired();

            builder
                .HasOne(p => p.Consorcio)
                .WithMany(p => p.Pagamentos)
                .HasConstraintName("FK_CONSORCIO_PAGAMENTO")
                .HasForeignKey(p => p.ConsorcioId)
                .IsRequired(false);

            builder
                .HasOne(p => p.Previdencia)
                .WithMany(p => p.Pagamentos)
                .HasConstraintName("FK_PREVIDENCIA_PAGAMENTO")
                .HasForeignKey(p => p.PrevidenciaId)
                .IsRequired(false);
        }
    }
}
