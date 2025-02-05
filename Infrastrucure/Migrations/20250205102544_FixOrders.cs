using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class FixOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 2, 5, 10, 25, 44, 422, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 2, 5, 10, 25, 44, 422, DateTimeKind.Utc).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2025, 2, 5, 10, 25, 44, 422, DateTimeKind.Utc).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2025, 2, 5, 10, 25, 44, 422, DateTimeKind.Utc).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 2, 5, 10, 25, 44, 422, DateTimeKind.Utc).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 2, 5, 10, 25, 44, 422, DateTimeKind.Utc).AddTicks(9154));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4300));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2025, 2, 3, 15, 24, 35, 706, DateTimeKind.Utc).AddTicks(4293));
        }
    }
}
