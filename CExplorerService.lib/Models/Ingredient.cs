using CExplorerService.lib.Models.Base;
using System.Collections.Generic;

namespace CExplorerService.lib.Models
{
    public class Ingredient : EntityBase
    {
        public IngredientBase IngredientBase { get; set; }
        public int IngredientBaseId { get; set; }

        public double Volume { get; set; }
        public string Dosage { get; set; }

        public int CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
    }
}
