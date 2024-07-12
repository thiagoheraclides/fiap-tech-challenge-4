using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Br.Com.Fiap.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Primeira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CONSORCIO",
                columns: table => new
                {
                    CD_CONSORCIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_TIPO = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DTH_INICIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DTH_FIM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VL_PREMIO = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    VL_PARCELA = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    NR_PRAZO = table.Column<int>(type: "int", nullable: false),
                    VL_TAXA_ADMINISTRACAO = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    TX_OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSORCIO", x => x.CD_CONSORCIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERFIL",
                columns: table => new
                {
                    CD_PERFIL = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_PERFIL = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DS_PERFIL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    DT_REGISTRO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.CD_PERFIL);
                });

            migrationBuilder.CreateTable(
                name: "TB_PREVIDENCIA",
                columns: table => new
                {
                    CD_PREVIDENCIA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_TIPO = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DTH_INICIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DTH_FIM = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VL_RETORNO = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    VL_PARCELA = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    DS_TRIBUTACAO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VL_TAXA_ADMINISTRACAO = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    TX_OBSERVACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DS_MODALIDADE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VL_RENTABILIDADE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    VL_ACUMULADO = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PREVIDENCIA", x => x.CD_PREVIDENCIA);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_USUARIO",
                columns: table => new
                {
                    CD_TIPO_USUARIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_TIPO_USUARIO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DS_TIPO_USUARIO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    DT_REGISTRO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_USUARIO", x => x.CD_TIPO_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    CD_USUARIO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NR_CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NM_USUARIO = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DS_EMAIL = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DS_LOGIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TX_SENHA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DT_ULTIMO_ACESSO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CD_PERFIL = table.Column<long>(type: "bigint", nullable: true),
                    CD_TIPO_USUARIO = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.CD_USUARIO);
                    table.ForeignKey(
                        name: "FK_PERFIL",
                        column: x => x.CD_PERFIL,
                        principalTable: "TB_PERFIL",
                        principalColumn: "CD_PERFIL");
                    table.ForeignKey(
                        name: "FK_TIPO_USUARIO",
                        column: x => x.CD_TIPO_USUARIO,
                        principalTable: "TB_TIPO_USUARIO",
                        principalColumn: "CD_TIPO_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    CD_ENDERECO = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TX_CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TX_LOGRADOURO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NUM_LOGRADOURO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TX_COMPLEMENTO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TX_CIDADE = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TX_ESTADO = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    CD_USUARIO = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.CD_ENDERECO);
                    table.ForeignKey(
                        name: "FK_USUARIO",
                        column: x => x.CD_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "CD_USUARIO");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_CD_USUARIO",
                table: "TB_ENDERECO",
                column: "CD_USUARIO",
                unique: true,
                filter: "[CD_USUARIO] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_CD_PERFIL",
                table: "TB_USUARIO",
                column: "CD_PERFIL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_CD_TIPO_USUARIO",
                table: "TB_USUARIO",
                column: "CD_TIPO_USUARIO");

            migrationBuilder.CreateIndex(
                name: "UK_USUARIO_LOGIN_UNIQUE",
                table: "TB_USUARIO",
                column: "DS_LOGIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_USUARIO_NRCPF_UNIQUE",
                table: "TB_USUARIO",
                column: "NR_CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONSORCIO");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_PREVIDENCIA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_PERFIL");

            migrationBuilder.DropTable(
                name: "TB_TIPO_USUARIO");
        }
    }
}
