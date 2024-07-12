using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("TB_PEDIDO");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_PEDIDO");

            builder.Property(p => p.Id)
                .HasColumnName("CD_PEDIDO")               
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

            builder.Property(p => p.DataContratacao)
                .HasColumnName("DTH_CONTRATACAO")
                .IsRequired();

            builder
                .HasOne(p => p.Usuario)
                .WithMany(p => p.Pedidos)
                .HasConstraintName("FK_USUARIO_PEDIDO")
                .HasForeignKey(p => p.UsuarioId)
                .IsRequired();

            builder
                .HasOne(p => p.Consorcio)
                .WithMany(p => p.Pedidos)
                .HasConstraintName("FK_CONSORCIO_PEDIDO")
                .HasForeignKey(p => p.ConsorcioId)
                .IsRequired(false);

            builder
                .HasOne(p => p.Previdencia)
                .WithMany(p => p.Pedidos)
                .HasConstraintName("FK_PREVIDENCIA_PEDIDO")
                .HasForeignKey(p => p.PrevidenciaId)
                .IsRequired(false);

        }
    }
}
