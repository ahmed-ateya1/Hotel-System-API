using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNum = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNum);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("02454e31-1236-4b7b-805f-7ecec9856090"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 14, 46, 56, 291, DateTimeKind.Utc).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("6e6fe821-13d2-4567-b674-f616d79e264a"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 14, 46, 56, 291, DateTimeKind.Utc).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("9b53e271-19fd-4b84-a14c-598e536ea22c"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 14, 46, 56, 291, DateTimeKind.Utc).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("aef0a7d2-1e79-4bdf-8d3e-b46de9f8656e"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 14, 46, 56, 291, DateTimeKind.Utc).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("bcfad10a-d4fc-44f1-b5b1-0f5aa2c66147"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 14, 46, 56, 291, DateTimeKind.Utc).AddTicks(9550));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("02454e31-1236-4b7b-805f-7ecec9856090"),
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("6e6fe821-13d2-4567-b674-f616d79e264a"),
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("9b53e271-19fd-4b84-a14c-598e536ea22c"),
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("aef0a7d2-1e79-4bdf-8d3e-b46de9f8656e"),
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("bcfad10a-d4fc-44f1-b5b1-0f5aa2c66147"),
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
