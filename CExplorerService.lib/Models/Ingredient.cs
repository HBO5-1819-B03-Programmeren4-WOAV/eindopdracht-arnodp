using CExplorerService.lib.Models.Base;
using System.Collections.Generic;

namespace CExplorerService.lib.Models
{
    public class Ingredient : EntityBase
    {
        public IngredientBase IngredientBase { get; set; }
        public double Volume { get; set; }
        public string Dosage { get; set; }

        public virtual ICollection<CocktailIngredient> CocktailsWithIngredients { get; set; }
    }
}
