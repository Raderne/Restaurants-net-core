using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastrucure.Migrations
{
    /// <inheritdoc />
    public partial class SecondSeedRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "ownerId",
                table: "Restaurants",
                newName: "OwnerId");

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "LastModified", "LastModifiedBy", "Name", "OwnerId", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Restaurant 1", null, "1234567890" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Restaurant 2", null, "1234567590" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "ImageUrl", "LastModified", "LastModifiedBy", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Menu 1", 10.00m, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Menu 2", 20.00m, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Menu 3", 30.00m, 2 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, "Menu 4", 40.00m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Restaurants",
                newName: "ownerId");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
