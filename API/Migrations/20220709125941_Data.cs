using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shabroek.Kantinescherm.API.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { 1, "Drank" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { 2, "Broodjes" });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "PriceId", "GroupId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Coca Cola", 1.8m },
                    { 2, 1, "Fanta", 1.8m },
                    { 3, 2, "Kroket", 2.1m },
                    { 4, 2, "Frikadel", 2.10m },
                    { 5, 2, "Jong Brabant", 3.5m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "PriceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "PriceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "PriceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "PriceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prices",
                keyColumn: "PriceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
