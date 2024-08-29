using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VillaID",
                table: "VillaNumbers",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "VillaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillaNumbers");

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
    }
}
