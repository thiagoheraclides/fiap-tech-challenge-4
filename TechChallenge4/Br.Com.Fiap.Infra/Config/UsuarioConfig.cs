using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");

            builder
                .HasKey(u => u.Id)
                .HasName("PK_USUARIO");

            builder.Property(u => u.Id)
                .HasColumnName("CD_USUARIO")                      
                .IsRequired();

            builder.Property(u => u.Cpf)
                .HasColumnName("NR_CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnName("NM_USUARIO")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("DS_EMAIL")
                .HasMaxLength(300);

            builder.Property(u => u.Login)
                .HasColumnName("DS_LOGIN")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("TX_SENHA")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.UltimoAcesso)
                .HasColumnName("DT_ULTIMO_ACESSO");

            builder.Property(u => u.TipoUsuarioId)
                .HasColumnName("CD_TIPO_USUARIO")
                .IsRequired();

            builder.Property(u => u.PerfilId)
                .HasColumnName("CD_PERFIL")
                .IsRequired(false);

            builder
                .HasOne(u => u.TipoUsuario)
                .WithMany(u => u.Usuarios)
                .HasConstraintName("FK_TIPO_USUARIO")
                .HasForeignKey(u => u.TipoUsuarioId)
                .IsRequired();

            builder
                .HasOne(u => u.Perfil)
                .WithMany(u => u.Usuarios)
                .HasConstraintName("FK_PERFIL")
                .HasForeignKey(u => u.PerfilId)
                .IsRequired(false);

            builder
                .HasIndex(u => u.Cpf)
                .HasDatabaseName("UK_USUARIO_NRCPF_UNIQUE")
                .IsUnique();

            builder
                .HasIndex(u => u.Login)
                .HasDatabaseName("UK_USUARIO_LOGIN_UNIQUE")
                .IsUnique();

        }
    }
}
