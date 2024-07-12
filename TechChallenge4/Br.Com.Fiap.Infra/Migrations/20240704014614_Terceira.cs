using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Br.Com.Fiap.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Terceira : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_LANCE",
                columns: table => new
                {
                    CD_LANCE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CD_CONSORCIO_LANCE = table.Column<int>(type: "int", nullable: true),
                    CD_USUARIO_LANCE = table.Column<long>(type: "bigint", nullable: false),
                    DTH_LANCE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VL_LANCE = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANCE", x => x.CD_LANCE);
                    table.ForeignKey(
                        name: "FK_CONSORCIO_LANCE",
                        column: x => x.CD_CONSORCIO_LANCE,
                        principalTable: "TB_CONSORCIO",
                        principalColumn: "CD_CONSORCIO");
                    table.ForeignKey(
                        name: "FK_USUARIO_LANCE",
                        column: x => x.CD_USUARIO_LANCE,
                        principalTable: "TB_USUARIO",
                        principalColumn: "CD_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_LANCE_CD_CONSORCIO_LANCE",
                table: "TB_LANCE",
                column: "CD_CONSORCIO_LANCE");

            migrationBuilder.CreateIndex(
                name: "IX_TB_LANCE_CD_USUARIO_LANCE",
                table: "TB_LANCE",
                column: "CD_USUARIO_LANCE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_LANCE");
        }
    }
}
