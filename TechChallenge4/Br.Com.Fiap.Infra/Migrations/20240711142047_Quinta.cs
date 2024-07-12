using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Br.Com.Fiap.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Quinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_RESGATE",
                columns: table => new
                {
                    CD_RESGATE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CD_PREVIDENCIA = table.Column<int>(type: "int", nullable: true),
                    CD_USUARIO_PREVIDENCIA = table.Column<long>(type: "bigint", nullable: false),
                    DTH_RESGATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VL_RESGATE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESGATE", x => x.CD_RESGATE);
                    table.ForeignKey(
                        name: "FK_PREVIDENCIA_RESGATE",
                        column: x => x.CD_PREVIDENCIA,
                        principalTable: "TB_PREVIDENCIA",
                        principalColumn: "CD_PREVIDENCIA");
                    table.ForeignKey(
                        name: "FK_USUARIO_RESGATE",
                        column: x => x.CD_USUARIO_PREVIDENCIA,
                        principalTable: "TB_USUARIO",
                        principalColumn: "CD_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESGATE_CD_PREVIDENCIA",
                table: "TB_RESGATE",
                column: "CD_PREVIDENCIA");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RESGATE_CD_USUARIO_PREVIDENCIA",
                table: "TB_RESGATE",
                column: "CD_USUARIO_PREVIDENCIA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_RESGATE");
        }
    }
}
