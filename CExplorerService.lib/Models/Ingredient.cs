using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CExplorerService.lib.Models
{
    public class Ingredient 
    {
        [Key]
        public int Id { get; set; }

        public IngredientBase IngredientBase { get; set; }
        public double Volume { get; set; }
        public string Dosage { get; set; }

        public virtual ICollection<CocktailIngredient> CocktailsWithIngredients { get; set; }
    }
}
