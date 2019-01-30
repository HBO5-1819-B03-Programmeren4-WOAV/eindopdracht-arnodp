using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CExplorerService.WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientBase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(nullable: true),
                    Partial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cocktails_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientBaseId = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                    Dosage = table.Column<string>(nullable: true),
                    CocktailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientBase_IngredientBaseId",
                        column: x => x.IngredientBaseId,
                        principalTable: "IngredientBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IngredientBase",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cachaça" },
                    { 19, "Egg White" },
                    { 18, "Pisco" },
                    { 17, "Sparkling Water" },
                    { 16, "Sugar Syrup" },
                    { 15, "Coke" },
                    { 14, "Lemon Juice" },
                    { 12, "Triple Sec" },
                    { 11, "Gomme Syrup" },
                    { 13, "Gin" },
                    { 9, "Tequila" },
                    { 8, "Lime Juice" },
                    { 7, "Orgeat Syrup" },
                    { 6, "Orange Curaçao" },
                    { 5, "Dark Rum" },
                    { 4, "White Rum" },
                    { 3, "Sugar" },
                    { 2, "Lime" },
                    { 10, "Vodka" }
                });

            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "Id", "Country" },
                values: new object[,]
                {
                    { 1, "Brazil" },
                    { 2, "United States" },
                    { 3, "United Kingdom" },
                    { 4, "Peru" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Partial", "Question" },
                values: new object[,]
                {
                    { 2, "GuessIngredient", "Wich ingredient is missing ?" },
                    { 1, "GuessCocktail", "Wich cocktail can you make with these ingredients ?" },
                    { 3, "GuessOrigin", "What is the origin of this cocktail ?" }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "Name", "OriginId" },
                values: new object[,]
                {
                    { 1, "Caipirinha", 1 },
                    { 2, "Mai-Thai", 2 },
                    { 3, "Long island ice tea", 2 },
                    { 4, "John Collins", 3 },
                    { 5, "Pisco Sour", 4 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CocktailId", "Dosage", "IngredientBaseId", "Volume" },
                values: new object[,]
                {
                    { 1, 1, "cl", 1, 5.0 },
                    { 22, 5, "cl", 8, 3.0 },
                    { 21, 5, "cl", 18, 4.5 },
                    { 20, 4, "cl", 17, 6.0 },
                    { 19, 4, "cl", 16, 1.5 },
                    { 18, 4, "cl", 14, 3.0 },
                    { 17, 4, "cl", 13, 4.5 },
                    { 16, 3, "dash", 15, 1.0 },
                    { 15, 3, "cl", 14, 2.5 },
                    { 14, 3, "cl", 13, 1.5 },
                    { 13, 3, "cl", 12, 1.5 },
                    { 12, 3, "cl", 11, 3.0 },
                    { 11, 3, "cl", 4, 1.5 },
                    { 10, 3, "cl", 10, 1.5 },
                    { 9, 3, "cl", 9, 1.5 },
                    { 8, 2, "cl", 8, 1.0 },
                    { 7, 2, "cl", 7, 1.5 },
                    { 6, 2, "cl", 6, 1.5 },
                    { 5, 2, "cl", 5, 2.0 },
                    { 4, 2, "cl", 4, 4.0 },
                    { 3, 1, "teaspoons", 3, 2.0 },
                    { 2, 1, "cut into 4 wedges", 2, 0.5 },
                    { 23, 5, "cl", 16, 2.0 },
                    { 24, 5, "", 19, 1.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_OriginId",
                table: "Cocktails",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CocktailId",
                table: "Ingredients",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientBaseId",
                table: "Ingredients",
                column: "IngredientBaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "IngredientBase");

            migrationBuilder.DropTable(
                name: "Origins");
        }
    }
}
