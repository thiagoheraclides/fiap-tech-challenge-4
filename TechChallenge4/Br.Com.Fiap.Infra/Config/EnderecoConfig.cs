using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TB_ENDERECO");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_ENDERECO");

            builder.Property(p => p.Id)
                .HasColumnName("CD_ENDERECO")                
                .IsRequired();

            builder.Property(p => p.Cep)
                .HasColumnName("TX_CEP")
                .HasMaxLength(8);

            builder.Property(p => p.Logradouro)
                .HasColumnName("TX_LOGRADOURO")
                .HasMaxLength(100);

            builder.Property(p => p.Numero)
                .HasColumnName("NUM_LOGRADOURO")
                .HasMaxLength(20);

            builder.Property(p => p.Complemento)
                .HasColumnName("TX_COMPLEMENTO")
                .HasMaxLength(100);

            builder.Property(p => p.Cidade)
                .HasColumnName("TX_CIDADE")
                .HasMaxLength(60);

            builder.Property(p => p.Estado)
                .HasColumnName("TX_ESTADO")
                .HasMaxLength(2);

            builder.Property(u => u.UsuarioId)
                .HasColumnName("CD_USUARIO")
                .IsRequired(false);

            builder
                .HasOne(u => u.Usuario)
                .WithOne(u => u.Endereco)
                .HasForeignKey<Endereco>(u => u.UsuarioId)
                .HasConstraintName("FK_USUARIO")                
                .IsRequired(false);
        }
    }
}
