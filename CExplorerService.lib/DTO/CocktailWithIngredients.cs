using System.Collections.Generic;

namespace CExplorerService.lib.DTO
{
    public class CocktailWithIngredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<IngredientBasic> Ingredients { get; set; }
    }
}
