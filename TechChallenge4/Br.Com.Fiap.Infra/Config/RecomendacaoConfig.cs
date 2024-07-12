using Br.Com.Fiap.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Br.Com.Fiap.Infra.Config
{
    internal class RecomendacaoConfig : IEntityTypeConfiguration<Recomendacao>
    {
        public void Configure(EntityTypeBuilder<Recomendacao> builder)
        {
            builder.ToTable("TB_RECOMENDACAO_INVESTIMENTO");

            builder
                .HasKey(p => p.Id)
                .HasName("PK_RECOMENDACAO_INVESTIMENTO");

            builder.Property(p => p.Id)
                .HasColumnName("CD_RECOMENDACAO_INVESTIMENTO")
                .HasColumnType("BIGINT")
                .IsRequired();

            builder.Property(p => p.UsuarioId)
                .HasColumnName("CD_USUARIO_INVESTIDOR")
                .IsRequired();

            builder.Property(p => p.ConsultorId)
                .HasColumnName("CD_USUARIO_CONSULTOR")
                .IsRequired();

            builder.Property(p => p.AtivoId)
                .HasColumnName("CD_ATIVO_INVESTIMENTO")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VL_COMPRA_SIMULACAO")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QT_COMPRA_SIMULACAO")
                .IsRequired();

            builder.Property(p => p.Data)
                .HasColumnName("DT_COMPRA_SIMULACAO")
                .IsRequired();

            builder.Property(p => p.RentabilidadeEmDias)
                .HasColumnName("NR_TEMPO_DIAS_RETABILIDADE")
                .IsRequired();

            builder.Property(p => p.Observacao)
                .HasColumnName("DS_OBSERVACAO")
                .HasMaxLength(500);

            //builder
            //    .HasOne(p => p.Usuario)
            //    .WithMany(p => p.RecomendacoesUsuario)
            //    .HasConstraintName("FK_USUARIO_INVESTIDOR")
            //    .HasForeignKey(p => p.UsuarioId)                
            //    .IsRequired();

            // builder
            //    .HasOne(p => p.Consultor)
            //    .WithMany(p => p.RecomendacoesConsultor)
            //    .HasConstraintName("FK_USUARIO_CONSULTOR")
            //    .HasForeignKey(p => p.ConsultorId)                
            //    .IsRequired();

            builder
                .HasOne(p => p.Ativo)
                .WithMany(p => p.Recomendacoes)
                .HasConstraintName("FK_RECOME_INVESTIMENTO_ATIVO")
                .HasForeignKey(p => p.AtivoId)
                .IsRequired();

            builder
                .HasIndex(p => p.UsuarioId)
                .HasDatabaseName("IDX_USUARIO_INVESTIDOR_RECOMENDACAO");

            builder
                .HasIndex(p => p.ConsultorId)
                .HasDatabaseName("IDX_USUARIO_CONSULTOR_RECOMENDACAO");

            builder
                .HasIndex(p => p.AtivoId)
                .HasDatabaseName("IDX_RECOME_INVESTIMENTO_ATIVO");
        }
    }
}
