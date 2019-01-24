
namespace CExplorerService.lib.DTO
{
    public class GuessIngredientData
    {
        public CocktailWithIngredients cocktail { get; set; }

        public string correctanswer { get; set; }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
    }
}
