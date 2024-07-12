﻿// <auto-generated />
using System;
using Br.Com.Fiap.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Br.Com.Fiap.Infra.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240711142047_Quinta")]
    partial class Quinta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Consorcio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_CONSORCIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Inicio")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_INICIO");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TX_OBSERVACAO");

                    b.Property<decimal>("Parcela")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_PARCELA");

                    b.Property<int>("Prazo")
                        .HasColumnType("int")
                        .HasColumnName("NR_PRAZO");

                    b.Property<decimal>("Premio")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_PREMIO");

                    b.Property<decimal>("TaxaAdministracao")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_TAXA_ADMINISTRACAO");

                    b.Property<DateTime?>("Termino")
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_FIM");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("DS_TIPO");

                    b.HasKey("Id")
                        .HasName("PK_CONSORCIO");

                    b.ToTable("TB_CONSORCIO", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CD_ENDERECO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("TX_CEP");

                    b.Property<string>("Cidade")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("TX_CIDADE");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TX_COMPLEMENTO");

                    b.Property<string>("Estado")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("TX_ESTADO");

                    b.Property<string>("Logradouro")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TX_LOGRADOURO");

                    b.Property<string>("Numero")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NUM_LOGRADOURO");

                    b.Property<long?>("UsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("CD_USUARIO");

                    b.HasKey("Id")
                        .HasName("PK_ENDERECO");

                    b.HasIndex("UsuarioId")
                        .IsUnique()
                        .HasFilter("[CD_USUARIO] IS NOT NULL");

                    b.ToTable("TB_ENDERECO", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Lance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_LANCE");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConsorcioId")
                        .HasColumnType("int")
                        .HasColumnName("CD_CONSORCIO_LANCE");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_LANCE");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("CD_USUARIO_LANCE");

                    b.Property<decimal>("Valor")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_LANCE");

                    b.HasKey("Id")
                        .HasName("PK_LANCE");

                    b.HasIndex("ConsorcioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_LANCE", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Pagamento", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)")
                        .HasColumnName("CD_PAGAMENTO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<int?>("ConsorcioId")
                        .HasColumnType("int")
                        .HasColumnName("CD_CONSORCIO_CONTRATADO");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_PAGAMENTO");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_VENCIMENTO");

                    b.Property<decimal>("Juros")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_JUROS");

                    b.Property<decimal>("Multa")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_MULTA");

                    b.Property<int?>("PrevidenciaId")
                        .HasColumnType("int")
                        .HasColumnName("CD_PREVIDENCIA_CONTRATADA");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("CD_CONTRATANTE");

                    b.Property<decimal>("Valor")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_PAGAMENTO");

                    b.Property<decimal>("ValorTotal")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_PAGAMENTO_TOTAL");

                    b.HasKey("Id")
                        .HasName("PK_PAGAMENTO");

                    b.HasIndex("ConsorcioId");

                    b.HasIndex("PrevidenciaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_PAGAMENTO", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_PEDIDO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConsorcioId")
                        .HasColumnType("int")
                        .HasColumnName("CD_CONSORCIO_CONTRATADO");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_CONTRATACAO");

                    b.Property<int?>("PrevidenciaId")
                        .HasColumnType("int")
                        .HasColumnName("CD_PREVIDENCIA_CONTRATADA");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("CD_CONTRATANTE");

                    b.HasKey("Id")
                        .HasName("PK_PEDIDO");

                    b.HasIndex("ConsorcioId");

                    b.HasIndex("PrevidenciaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_PEDIDO", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Perfil", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CD_PERFIL");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_REGISTRO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("DS_PERFIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NM_PERFIL");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("FL_ATIVO");

                    b.HasKey("Id")
                        .HasName("PK_PERFIL");

                    b.ToTable("TB_PERFIL", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Previdencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_PREVIDENCIA");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Inicio")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_INICIO");

                    b.Property<string>("Modalidade")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("DS_MODALIDADE");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TX_OBSERVACAO");

                    b.Property<decimal>("Parcela")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_PARCELA");

                    b.Property<decimal>("Rentabilidade")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_RENTABILIDADE");

                    b.Property<decimal>("Retorno")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_RETORNO");

                    b.Property<decimal>("TaxaAdministracao")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_TAXA_ADMINISTRACAO");

                    b.Property<DateTime?>("Termino")
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_FIM");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("DS_TIPO");

                    b.Property<string>("Tributacao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("DS_TRIBUTACAO");

                    b.Property<decimal>("ValorAcumulado")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_ACUMULADO");

                    b.HasKey("Id")
                        .HasName("PK_PREVIDENCIA");

                    b.ToTable("TB_PREVIDENCIA", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Resgate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CD_RESGATE");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("DTH_RESGATE");

                    b.Property<int?>("PrevidenciaId")
                        .HasColumnType("int")
                        .HasColumnName("CD_PREVIDENCIA");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("CD_USUARIO_PREVIDENCIA");

                    b.Property<decimal>("Valor")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)")
                        .HasColumnName("VL_RESGATE");

                    b.HasKey("Id")
                        .HasName("PK_RESGATE");

                    b.HasIndex("PrevidenciaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_RESGATE", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.TipoUsuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CD_TIPO_USUARIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_REGISTRO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("DS_TIPO_USUARIO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NM_TIPO_USUARIO");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("FL_ATIVO");

                    b.HasKey("Id")
                        .HasName("PK_TIPO_USUARIO");

                    b.ToTable("TB_TIPO_USUARIO", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CD_USUARIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("NR_CPF");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("DS_EMAIL");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DS_LOGIN");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("NM_USUARIO");

                    b.Property<long?>("PerfilId")
                        .HasColumnType("bigint")
                        .HasColumnName("CD_PERFIL");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("TX_SENHA");

                    b.Property<long>("TipoUsuarioId")
                        .HasColumnType("bigint")
                        .HasColumnName("CD_TIPO_USUARIO");

                    b.Property<DateTime>("UltimoAcesso")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_ULTIMO_ACESSO");

                    b.HasKey("Id")
                        .HasName("PK_USUARIO");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasDatabaseName("UK_USUARIO_NRCPF_UNIQUE");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasDatabaseName("UK_USUARIO_LOGIN_UNIQUE");

                    b.HasIndex("PerfilId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("TB_USUARIO", (string)null);
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Endereco", b =>
                {
                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("Br.Com.Fiap.Domain.Entidades.Endereco", "UsuarioId")
                        .HasConstraintName("FK_USUARIO");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Lance", b =>
                {
                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Consorcio", "Consorcio")
                        .WithMany("Lances")
                        .HasForeignKey("ConsorcioId")
                        .HasConstraintName("FK_CONSORCIO_LANCE");

                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Lances")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_USUARIO_LANCE");

                    b.Navigation("Consorcio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Pagamento", b =>
                {
                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Consorcio", "Consorcio")
                        .WithMany("Pagamentos")
                        .HasForeignKey("ConsorcioId")
                        .HasConstraintName("FK_CONSORCIO_PAGAMENTO");

                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Previdencia", "Previdencia")
                        .WithMany("Pagamentos")
                        .HasForeignKey("PrevidenciaId")
                        .HasConstraintName("FK_PREVIDENCIA_PAGAMENTO");

                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Pagamentos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_USUARIO_PAGAMENTO");

                    b.Navigation("Consorcio");

                    b.Navigation("Previdencia");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Pedido", b =>
                {
                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Consorcio", "Consorcio")
                        .WithMany("Pedidos")
                        .HasForeignKey("ConsorcioId")
                        .HasConstraintName("FK_CONSORCIO_PEDIDO");

                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Previdencia", "Previdencia")
                        .WithMany("Pedidos")
                        .HasForeignKey("PrevidenciaId")
                        .HasConstraintName("FK_PREVIDENCIA_PEDIDO");

                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_USUARIO_PEDIDO");

                    b.Navigation("Consorcio");

                    b.Navigation("Previdencia");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Resgate", b =>
                {
                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Previdencia", "Previdencia")
                        .WithMany("Resgates")
                        .HasForeignKey("PrevidenciaId")
                        .HasConstraintName("FK_PREVIDENCIA_RESGATE");

                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Resgates")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_USUARIO_RESGATE");

                    b.Navigation("Previdencia");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Usuario", b =>
                {
                    b.HasOne("Br.Com.Fiap.Domain.Entidades.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .HasConstraintName("FK_PERFIL");

                    b.HasOne("Br.Com.Fiap.Domain.Entidades.TipoUsuario", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TIPO_USUARIO");

                    b.Navigation("Perfil");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Consorcio", b =>
                {
                    b.Navigation("Lances");

                    b.Navigation("Pagamentos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Perfil", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Previdencia", b =>
                {
                    b.Navigation("Pagamentos");

                    b.Navigation("Pedidos");

                    b.Navigation("Resgates");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.TipoUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Br.Com.Fiap.Domain.Entidades.Usuario", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Lances");

                    b.Navigation("Pagamentos");

                    b.Navigation("Pedidos");

                    b.Navigation("Resgates");
                });
#pragma warning restore 612, 618
        }
    }
}
