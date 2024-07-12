using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class LanceConfig : IEntityTypeConfiguration<Lance>
    {
        public void Configure(EntityTypeBuilder<Lance> builder)
        {
            builder.ToTable("TB_LANCE");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_LANCE");

            builder.Property(p => p.Id)
                .HasColumnName("CD_LANCE")
                .IsRequired();

            builder.Property(p => p.ConsorcioId)
                .HasColumnName("CD_CONSORCIO_LANCE")
                .IsRequired(false);

            builder.Property(p => p.UsuarioId)
                .HasColumnName("CD_USUARIO_LANCE")
                .IsRequired();

            builder.Property(p => p.Data)
                .HasColumnName("DTH_LANCE")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VL_LANCE")
                .HasPrecision(8,2)
                .IsRequired();

            builder
                .HasOne(p => p.Usuario)
                .WithMany(p => p.Lances)
                .HasConstraintName("FK_USUARIO_LANCE")
                .HasForeignKey(p => p.UsuarioId)
                .IsRequired();

            builder
                .HasOne(p => p.Consorcio)
                .WithMany(p => p.Lances)
                .HasConstraintName("FK_CONSORCIO_LANCE")
                .HasForeignKey(p => p.ConsorcioId)
                .IsRequired(false);
        }
    }
}
