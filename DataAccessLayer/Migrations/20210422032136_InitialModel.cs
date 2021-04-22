using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gasto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsGastoFijo = table.Column<bool>(type: "bit", nullable: false),
                    CantidadCuotas = table.Column<int>(type: "int", nullable: false),
                    GastoPagado = table.Column<bool>(type: "bit", nullable: false),
                    GastoInactivo = table.Column<bool>(type: "bit", nullable: false),
                    RazonInactivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaReactivacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsReactivable = table.Column<bool>(type: "bit", nullable: false),
                    FechaPagado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuota",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuotaNumero = table.Column<int>(type: "int", nullable: false),
                    CuotaPagada = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPagado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GastoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuota_Gasto_GastoId",
                        column: x => x.GastoId,
                        principalTable: "Gasto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuota_GastoId",
                table: "Cuota",
                column: "GastoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuota");

            migrationBuilder.DropTable(
                name: "Gasto");
        }
    }
}
