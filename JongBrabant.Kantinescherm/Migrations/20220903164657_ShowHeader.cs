using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JongBrabant.Kantinescherm.Migrations
{
    public partial class ShowHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowHeader",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowHeader",
                table: "Groups");
        }
    }
}
