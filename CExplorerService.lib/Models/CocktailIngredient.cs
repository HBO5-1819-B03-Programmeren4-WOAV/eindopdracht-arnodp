using System.ComponentModel.DataAnnotations.Schema;

namespace CExplorerService.lib.Models
{
    public class CocktailIngredient
    {
        [ForeignKey("Cocktail")]
        public int CocktailId { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }

        public Cocktail Cocktail { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
