using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class loadRegionsInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("015facbf-fde0-47b5-a977-3e62d1d96dad"), "WLG", "Wellington Region", "https://image.pexels.com/test1" },
                    { new Guid("99b4a4ae-5d0e-48e8-8f32-5cb071a8e427"), "AKL", "Auckland Region", "https://image.pexels.com/test1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("015facbf-fde0-47b5-a977-3e62d1d96dad"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("99b4a4ae-5d0e-48e8-8f32-5cb071a8e427"));
        }
    }
}
