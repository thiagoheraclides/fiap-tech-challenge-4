using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class TipoUsuarioConfig : IEntityTypeConfiguration<TipoUsuario>
    {
        public void Configure(EntityTypeBuilder<TipoUsuario> builder)
        {
            builder.ToTable("TB_TIPO_USUARIO");

            builder
                .HasKey(tp => tp.Id)                
                .HasName("PK_TIPO_USUARIO");

            builder.Property(tp => tp.Id)
                .HasColumnName("CD_TIPO_USUARIO")                           
                .IsRequired();

            builder.Property(tp => tp.Nome)
                .HasColumnName("NM_TIPO_USUARIO")
                .HasMaxLength(20);

            builder.Property(tp => tp.Descricao)
                .HasColumnName("DS_TIPO_USUARIO")
                .HasMaxLength(200);

            builder.Property(tp => tp.Status)
                .HasColumnName("FL_ATIVO")
                .IsRequired();

            builder.Property(tp => tp.CriadoEm)
                .HasColumnName("DT_REGISTRO")
                .IsRequired();
        }
    }
}
