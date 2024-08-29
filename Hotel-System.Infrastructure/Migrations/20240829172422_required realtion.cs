using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class requiredrealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "VillaID",
                table: "VillaNumbers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("02454e31-1236-4b7b-805f-7ecec9856090"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 24, 22, 371, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("6e6fe821-13d2-4567-b674-f616d79e264a"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 24, 22, 371, DateTimeKind.Utc).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("9b53e271-19fd-4b84-a14c-598e536ea22c"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 24, 22, 371, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("aef0a7d2-1e79-4bdf-8d3e-b46de9f8656e"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 24, 22, 371, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("bcfad10a-d4fc-44f1-b5b1-0f5aa2c66147"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 24, 22, 371, DateTimeKind.Utc).AddTicks(3989));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "VillaID",
                table: "VillaNumbers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("02454e31-1236-4b7b-805f-7ecec9856090"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 20, 39, 279, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("6e6fe821-13d2-4567-b674-f616d79e264a"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 20, 39, 279, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("9b53e271-19fd-4b84-a14c-598e536ea22c"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 20, 39, 279, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("aef0a7d2-1e79-4bdf-8d3e-b46de9f8656e"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 20, 39, 279, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "VillaID",
                keyValue: new Guid("bcfad10a-d4fc-44f1-b5b1-0f5aa2c66147"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 29, 17, 20, 39, 279, DateTimeKind.Utc).AddTicks(4738));
        }
    }
}
