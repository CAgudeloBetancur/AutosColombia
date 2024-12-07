using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACP.Migrations
{
    /// <inheritdoc />
    public partial class Fabricante_Color_modelos_relacion_con_vehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "Vehiculos");

            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "Vehiculos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FabricanteId",
                table: "Vehiculos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ColorId",
                table: "Vehiculos",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_FabricanteId",
                table: "Vehiculos",
                column: "FabricanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Colores_ColorId",
                table: "Vehiculos",
                column: "ColorId",
                principalTable: "Colores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Fabricantes_FabricanteId",
                table: "Vehiculos",
                column: "FabricanteId",
                principalTable: "Fabricantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Colores_ColorId",
                table: "Vehiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Fabricantes_FabricanteId",
                table: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_ColorId",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_FabricanteId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "Vehiculos");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
