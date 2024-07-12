using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class PerfilConfig : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("TB_PERFIL");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_PERFIL");

            builder.Property(p => p.Id)
                .HasColumnName("CD_PERFIL")                          
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NM_PERFIL")
                .HasMaxLength(20);

            builder.Property(p => p.Descricao)
                .HasColumnName("DS_PERFIL")
                .HasMaxLength(200);

            builder.Property(p => p.Status)
                .HasColumnName("FL_ATIVO")
                .IsRequired();

            builder.Property(p => p.CriadoEm)
                .HasColumnName("DT_REGISTRO")
                .IsRequired();
        }
    }
}
