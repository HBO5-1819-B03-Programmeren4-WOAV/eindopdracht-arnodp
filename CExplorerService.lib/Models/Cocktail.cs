using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CExplorerService.lib.Models
{
    public class Cocktail 
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Origin Origin { get; set; }
        public virtual ICollection<CocktailIngredient> CocktailIngredients { get; set; }
    }
}
