using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ACP.Migrations
{
    /// <inheritdoc />
    public partial class Referencias_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Colores",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("3cff74f8-ad37-4b87-9307-0b9c541fad5a"), "Negro" },
                    { new Guid("7a78cc93-67e2-4e5c-a0cc-cf8eb4875595"), "Azul" },
                    { new Guid("7e4ae0c3-06ec-44a2-977d-89afd581e9ee"), "Rojo" }
                });

            migrationBuilder.InsertData(
                table: "Fabricantes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("3fb68109-47e4-4f97-b848-9059d2ced979"), "Chevrolet" },
                    { new Guid("62919438-9f32-449d-ae48-c72d0513c703"), "Toyota" },
                    { new Guid("c1e1821c-2d17-4454-b8ab-e956277a6b4a"), "Ford" }
                });

            migrationBuilder.InsertData(
                table: "Referencias",
                columns: new[] { "Id", "FabricanteId", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0339a85e-b0c0-446b-8e70-5e8ec18e23c4"), new Guid("c1e1821c-2d17-4454-b8ab-e956277a6b4a"), "Mustang" },
                    { new Guid("3dd53e95-b5ab-4cae-a9fc-f79a2c05c111"), new Guid("62919438-9f32-449d-ae48-c72d0513c703"), "Corolla" },
                    { new Guid("71cbc8ef-c32c-46fd-a618-93576c81a85a"), new Guid("c1e1821c-2d17-4454-b8ab-e956277a6b4a"), "F-150" },
                    { new Guid("b38ae64e-69e0-46e7-bb8a-7fbeb216e581"), new Guid("3fb68109-47e4-4f97-b848-9059d2ced979"), "Captiva" },
                    { new Guid("bba00774-444d-4839-836b-6125ebbd3bd6"), new Guid("62919438-9f32-449d-ae48-c72d0513c703"), "Camry" },
                    { new Guid("d2aebed3-aaf4-409d-9b23-477416b6ebe4"), new Guid("3fb68109-47e4-4f97-b848-9059d2ced979"), "Onix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("3cff74f8-ad37-4b87-9307-0b9c541fad5a"));

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("7a78cc93-67e2-4e5c-a0cc-cf8eb4875595"));

            migrationBuilder.DeleteData(
                table: "Colores",
                keyColumn: "Id",
                keyValue: new Guid("7e4ae0c3-06ec-44a2-977d-89afd581e9ee"));

            migrationBuilder.DeleteData(
                table: "Referencias",
                keyColumn: "Id",
                keyValue: new Guid("0339a85e-b0c0-446b-8e70-5e8ec18e23c4"));

            migrationBuilder.DeleteData(
                table: "Referencias",
                keyColumn: "Id",
                keyValue: new Guid("3dd53e95-b5ab-4cae-a9fc-f79a2c05c111"));

            migrationBuilder.DeleteData(
                table: "Referencias",
                keyColumn: "Id",
                keyValue: new Guid("71cbc8ef-c32c-46fd-a618-93576c81a85a"));

            migrationBuilder.DeleteData(
                table: "Referencias",
                keyColumn: "Id",
                keyValue: new Guid("b38ae64e-69e0-46e7-bb8a-7fbeb216e581"));

            migrationBuilder.DeleteData(
                table: "Referencias",
                keyColumn: "Id",
                keyValue: new Guid("bba00774-444d-4839-836b-6125ebbd3bd6"));

            migrationBuilder.DeleteData(
                table: "Referencias",
                keyColumn: "Id",
                keyValue: new Guid("d2aebed3-aaf4-409d-9b23-477416b6ebe4"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("3fb68109-47e4-4f97-b848-9059d2ced979"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("62919438-9f32-449d-ae48-c72d0513c703"));

            migrationBuilder.DeleteData(
                table: "Fabricantes",
                keyColumn: "Id",
                keyValue: new Guid("c1e1821c-2d17-4454-b8ab-e956277a6b4a"));

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
        }
    }
}
