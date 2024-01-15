using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JongBrabant.Kantinescherm.Migrations
{
    public partial class AddPriceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceListId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.PriceListId);
                });

            migrationBuilder.InsertData(
                table: "PriceLists",
                columns: new[] { "PriceListId", "Name" },
                values: new object[] { 1, "Kantine" });

            migrationBuilder.InsertData(
                table: "PriceLists",
                columns: new[] { "PriceListId", "Name" },
                values: new object[] { 2, "Smulhoek" });

            migrationBuilder.Sql("UPDATE Groups Set PriceListId = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PriceListId",
                table: "Groups",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_PriceLists_PriceListId",
                table: "Groups",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "PriceListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_PriceLists_PriceListId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_Groups_PriceListId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "PriceListId",
                table: "Groups");
        }
    }
}
