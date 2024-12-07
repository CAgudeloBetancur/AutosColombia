using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ACP.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Color_Fabricante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
