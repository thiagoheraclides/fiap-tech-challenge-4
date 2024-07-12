using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class ResgateConfig : IEntityTypeConfiguration<Resgate>
    {
        public void Configure(EntityTypeBuilder<Resgate> builder)
        {
            builder.ToTable("TB_RESGATE");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_RESGATE");

            builder.Property(p => p.Id)
                .HasColumnName("CD_RESGATE")
                .IsRequired();

            builder.Property(p => p.PrevidenciaId)
                .HasColumnName("CD_PREVIDENCIA")
                .IsRequired(false);

            builder.Property(p => p.UsuarioId)
                .HasColumnName("CD_USUARIO_PREVIDENCIA")
                .IsRequired();

            builder.Property(p => p.Data)
                .HasColumnName("DTH_RESGATE")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VL_RESGATE")
                .HasPrecision(8,2)
                .IsRequired();

            builder
                .HasOne(p => p.Usuario)
                .WithMany(p => p.Resgates)
                .HasConstraintName("FK_USUARIO_RESGATE")
                .HasForeignKey(p => p.UsuarioId)
                .IsRequired();

            builder
                .HasOne(p => p.Previdencia)
                .WithMany(p => p.Resgates)
                .HasConstraintName("FK_PREVIDENCIA_RESGATE")
                .HasForeignKey(p => p.PrevidenciaId)
                .IsRequired(false);
        }
    }
}
