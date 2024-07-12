using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Br.Com.Fiap.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Quarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PAGAMENTO",
                columns: table => new
                {
                    CD_PAGAMENTO = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CD_PREVIDENCIA_CONTRATADA = table.Column<int>(type: "int", nullable: true),
                    CD_CONSORCIO_CONTRATADO = table.Column<int>(type: "int", nullable: true),
                    CD_CONTRATANTE = table.Column<long>(type: "bigint", nullable: false),
                    DTH_VENCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DTH_PAGAMENTO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VL_PAGAMENTO = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    VL_MULTA = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    VL_JUROS = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    VL_PAGAMENTO_TOTAL = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => x.CD_PAGAMENTO);
                    table.ForeignKey(
                        name: "FK_CONSORCIO_PAGAMENTO",
                        column: x => x.CD_CONSORCIO_CONTRATADO,
                        principalTable: "TB_CONSORCIO",
                        principalColumn: "CD_CONSORCIO");
                    table.ForeignKey(
                        name: "FK_PREVIDENCIA_PAGAMENTO",
                        column: x => x.CD_PREVIDENCIA_CONTRATADA,
                        principalTable: "TB_PREVIDENCIA",
                        principalColumn: "CD_PREVIDENCIA");
                    table.ForeignKey(
                        name: "FK_USUARIO_PAGAMENTO",
                        column: x => x.CD_CONTRATANTE,
                        principalTable: "TB_USUARIO",
                        principalColumn: "CD_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PAGAMENTO_CD_CONSORCIO_CONTRATADO",
                table: "TB_PAGAMENTO",
                column: "CD_CONSORCIO_CONTRATADO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PAGAMENTO_CD_CONTRATANTE",
                table: "TB_PAGAMENTO",
                column: "CD_CONTRATANTE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PAGAMENTO_CD_PREVIDENCIA_CONTRATADA",
                table: "TB_PAGAMENTO",
                column: "CD_PREVIDENCIA_CONTRATADA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PAGAMENTO");
        }
    }
}
