using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JongBrabant.Kantinescherm.Migrations
{
    public partial class PricesAndGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_Prices_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Prices_GroupId",
                table: "Prices",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
