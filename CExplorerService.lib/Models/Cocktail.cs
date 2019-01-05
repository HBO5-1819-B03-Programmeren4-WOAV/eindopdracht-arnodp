using CExplorerService.lib.Models.Base;
using System.Collections.Generic;

namespace CExplorerService.lib.Models
{
    public class Cocktail : EntityBase
    {
        public string Name { get; set; }
        public Origin Origin { get; set; }
        public virtual ICollection<CocktailIngredient> CocktailIngredients { get; set; }
    }
}
