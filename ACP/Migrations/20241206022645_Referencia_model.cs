using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ACP.Migrations
{
    /// <inheritdoc />
    public partial class Referencia_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("0ecd599b-59d2-4eee-b88c-8ba5339f9e48"));

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("84d92f71-1ef7-41e9-b375-9896b50d3e3d"));

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("8b5d3724-5d63-42df-b1be-2f156d0f7d61"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("7b3a899e-e2f7-40b3-b37f-c54038aad3e2"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("c1d89a2d-4276-47ce-a1c7-c3c72b0f70a2"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("c94f4aad-f7f7-4080-9597-6385b2653472"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReferenciaId",
                table: "Vehiculos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Referencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencias_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colores",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("6f4347cb-8373-4ead-a5c1-5826acfc797e"), "Rojo" },
                    { new Guid("df061886-e595-4885-961a-e70dcfeb311a"), "Azul" },
                    { new Guid("f90b0c08-7047-413b-9266-9f219f002f0b"), "Negro" }
                });

            migrationBuilder.InsertData(
                table: "Fabricantes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("100ff16c-d9d6-46bf-97f9-4fef5697fcea"), "Chevrolet" },
                    { new Guid("649b3ca4-a2bf-40fe-985b-ea3900600a36"), "Ford" },
                    { new Guid("76071c15-6503-4485-9cc2-5c0bb73cf261"), "Toyota" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ReferenciaId",
                table: "Vehiculos",
                column: "ReferenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencias_FabricanteId",
                table: "Referencias",
                column: "FabricanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_Referencias_ReferenciaId",
                table: "Vehiculos",
                column: "ReferenciaId",
                principalTable: "Referencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_Referencias_ReferenciaId",
                table: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Referencias");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_ReferenciaId",
                table: "Vehiculos");

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("6f4347cb-8373-4ead-a5c1-5826acfc797e"));

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("df061886-e595-4885-961a-e70dcfeb311a"));

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("f90b0c08-7047-413b-9266-9f219f002f0b"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("100ff16c-d9d6-46bf-97f9-4fef5697fcea"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("649b3ca4-a2bf-40fe-985b-ea3900600a36"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("76071c15-6503-4485-9cc2-5c0bb73cf261"));

            migrationBuilder.DropColumn(
                name: "ReferenciaId",
                table: "Vehiculos");

            migrationBuilder.InsertData(
                table: "Colores",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0ecd599b-59d2-4eee-b88c-8ba5339f9e48"), "Azul" },
                    { new Guid("84d92f71-1ef7-41e9-b375-9896b50d3e3d"), "Rojo" },
                    { new Guid("8b5d3724-5d63-42df-b1be-2f156d0f7d61"), "Negro" }
                });

            migrationBuilder.InsertData(
                table: "Fabricantes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("7b3a899e-e2f7-40b3-b37f-c54038aad3e2"), "Toyota" },
                    { new Guid("c1d89a2d-4276-47ce-a1c7-c3c72b0f70a2"), "Ford" },
                    { new Guid("c94f4aad-f7f7-4080-9597-6385b2653472"), "Chevrolet" }
                });
        }
    }
}
