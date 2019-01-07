using CExplorerService.lib.Models.Base;
using System.Collections.Generic;

namespace CExplorerService.lib.Models
{
    public class Cocktail : EntityBase
    {
        public string Name { get; set; }

        public int OriginId { get; set; }
        public Origin Origin { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
