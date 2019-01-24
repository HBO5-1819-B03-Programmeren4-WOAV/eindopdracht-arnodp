using System.Collections.Generic;

namespace CExplorerService.lib.DTO
{
    public class CocktailDetailed
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string origin { get; set; }

        public virtual ICollection<IngredientBasic> Ingredients { get; set; }
    }
}
