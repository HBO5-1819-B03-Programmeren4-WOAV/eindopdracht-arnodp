using Microsoft.EntityFrameworkCore.Migrations;

namespace CExplorerService.WebAPI.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cocktails_Origins_OriginId",
                table: "Cocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientBases_IngredientBaseId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientBaseId",
                table: "Ingredients",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OriginId",
                table: "Cocktails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cocktails_Origins_OriginId",
                table: "Cocktails",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientBases_IngredientBaseId",
                table: "Ingredients",
                column: "IngredientBaseId",
                principalTable: "IngredientBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cocktails_Origins_OriginId",
                table: "Cocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientBases_IngredientBaseId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientBaseId",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OriginId",
                table: "Cocktails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cocktails_Origins_OriginId",
                table: "Cocktails",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientBases_IngredientBaseId",
                table: "Ingredients",
                column: "IngredientBaseId",
                principalTable: "IngredientBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
