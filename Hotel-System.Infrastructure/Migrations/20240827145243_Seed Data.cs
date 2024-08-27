using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel_System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Villas",
                type: "VARCHAR(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2147483647)",
                oldMaxLength: 2147483647);

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "VillaID", "Amenity", "CreatedDate", "ImageURL", "Occupancy", "Rate", "Sqft", "UpdatedDate", "VillaDescription", "VillaName" },
                values: new object[,]
                {
                    { new Guid("02454e31-1236-4b7b-805f-7ecec9856090"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Diamond Pool Villa" },
                    { new Guid("6e6fe821-13d2-4567-b674-f616d79e264a"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Diamond Villa" },
                    { new Guid("9b53e271-19fd-4b84-a14c-598e536ea22c"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", 4, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Royal Villa" },
                    { new Guid("aef0a7d2-1e79-4bdf-8d3e-b46de9f8656e"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", 4, 400.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Luxury Pool Villa" },
                    { new Guid("bcfad10a-d4fc-44f1-b5b1-0f5aa2c66147"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg", 4, 300.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "Premium Pool Villa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("02454e31-1236-4b7b-805f-7ecec9856090"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("6e6fe821-13d2-4567-b674-f616d79e264a"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("9b53e271-19fd-4b84-a14c-598e536ea22c"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("aef0a7d2-1e79-4bdf-8d3e-b46de9f8656e"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("bcfad10a-d4fc-44f1-b5b1-0f5aa2c66147"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Villas",
                type: "VARCHAR(2147483647)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(max)");
        }
    }
}
