using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Br.Com.Fiap.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PEDIDO",
                columns: table => new
                {
                    CD_PEDIDO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CD_PREVIDENCIA_CONTRATADA = table.Column<int>(type: "int", nullable: true),
                    CD_CONSORCIO_CONTRATADO = table.Column<int>(type: "int", nullable: true),
                    CD_CONTRATANTE = table.Column<long>(type: "bigint", nullable: false),
                    DTH_CONTRATACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO", x => x.CD_PEDIDO);
                    table.ForeignKey(
                        name: "FK_CONSORCIO_PEDIDO",
                        column: x => x.CD_CONSORCIO_CONTRATADO,
                        principalTable: "TB_CONSORCIO",
                        principalColumn: "CD_CONSORCIO");
                    table.ForeignKey(
                        name: "FK_PREVIDENCIA_PEDIDO",
                        column: x => x.CD_PREVIDENCIA_CONTRATADA,
                        principalTable: "TB_PREVIDENCIA",
                        principalColumn: "CD_PREVIDENCIA");
                    table.ForeignKey(
                        name: "FK_USUARIO_PEDIDO",
                        column: x => x.CD_CONTRATANTE,
                        principalTable: "TB_USUARIO",
                        principalColumn: "CD_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_CD_CONSORCIO_CONTRATADO",
                table: "TB_PEDIDO",
                column: "CD_CONSORCIO_CONTRATADO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_CD_CONTRATANTE",
                table: "TB_PEDIDO",
                column: "CD_CONTRATANTE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_CD_PREVIDENCIA_CONTRATADA",
                table: "TB_PEDIDO",
                column: "CD_PREVIDENCIA_CONTRATADA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PEDIDO");
        }
    }
}
