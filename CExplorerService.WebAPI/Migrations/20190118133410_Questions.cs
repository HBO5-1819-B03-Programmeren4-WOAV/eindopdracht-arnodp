using Microsoft.EntityFrameworkCore.Migrations;

namespace CExplorerService.WebAPI.Migrations
{
    public partial class Questions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cocktail_Origin_OriginId",
                table: "Cocktail");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Cocktail_CocktailId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientBase_IngredientBaseId",
                table: "Ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionBases",
                table: "QuestionBases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Origin",
                table: "Origin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cocktail",
                table: "Cocktail");

            migrationBuilder.RenameTable(
                name: "QuestionBases",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Origin",
                newName: "Origins");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "Cocktail",
                newName: "Cocktails");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_IngredientBaseId",
                table: "Ingredients",
                newName: "IX_Ingredients_IngredientBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_CocktailId",
                table: "Ingredients",
                newName: "IX_Ingredients_CocktailId");

            migrationBuilder.RenameIndex(
                name: "IX_Cocktail_OriginId",
                table: "Cocktails",
                newName: "IX_Cocktails_OriginId");

            migrationBuilder.AddColumn<string>(
                name: "Partial",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Origins",
                table: "Origins",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cocktails",
                table: "Cocktails",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Partial", "Question" },
                values: new object[] { 1, "GuessCocktail", "Wich cocktail can you make with these ingredients ?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Partial", "Question" },
                values: new object[] { 2, "GuessIngredient", "Wich ingredient is missing ?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Partial", "Question" },
                values: new object[] { 3, "GuessOrigin", "What is the origin of this cocktail ?" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cocktails_Origins_OriginId",
                table: "Cocktails",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Cocktails_CocktailId",
                table: "Ingredients",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientBase_IngredientBaseId",
                table: "Ingredients",
                column: "IngredientBaseId",
                principalTable: "IngredientBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cocktails_Origins_OriginId",
                table: "Cocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Cocktails_CocktailId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientBase_IngredientBaseId",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Origins",
                table: "Origins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cocktails",
                table: "Cocktails");

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Partial",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "QuestionBases");

            migrationBuilder.RenameTable(
                name: "Origins",
                newName: "Origin");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.RenameTable(
                name: "Cocktails",
                newName: "Cocktail");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_IngredientBaseId",
                table: "Ingredient",
                newName: "IX_Ingredient_IngredientBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_CocktailId",
                table: "Ingredient",
                newName: "IX_Ingredient_CocktailId");

            migrationBuilder.RenameIndex(
                name: "IX_Cocktails_OriginId",
                table: "Cocktail",
                newName: "IX_Cocktail_OriginId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionBases",
                table: "QuestionBases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Origin",
                table: "Origin",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cocktail",
                table: "Cocktail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cocktail_Origin_OriginId",
                table: "Cocktail",
                column: "OriginId",
                principalTable: "Origin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Cocktail_CocktailId",
                table: "Ingredient",
                column: "CocktailId",
                principalTable: "Cocktail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientBase_IngredientBaseId",
                table: "Ingredient",
                column: "IngredientBaseId",
                principalTable: "IngredientBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
