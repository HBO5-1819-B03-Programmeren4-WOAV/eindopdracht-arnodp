using Microsoft.EntityFrameworkCore.Migrations;

namespace CExplorerService.WebAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                column: "Volume",
                value: 0.5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                column: "Volume",
                value: 0.0);
        }
    }
}
