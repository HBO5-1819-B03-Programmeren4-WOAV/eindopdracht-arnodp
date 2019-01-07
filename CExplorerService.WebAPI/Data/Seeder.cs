//using CExplorerService.lib.Models;
//using System.Linq;

//namespace CExplorerService.WebAPI.Data
//{
//    public class Seeder
//    {
//        public static void Seed(CExplorerServiceContext context)
//        {
//            if (context.Cocktails.Any())
//                return;

//            var IngredientBases = new IngredientBase[]
//            {
//                new IngredientBase { Name = "Cachaça"},//0
//                new IngredientBase { Name = "Lime"},//1
//                new IngredientBase { Name = "Sugar"},//2
//                new IngredientBase { Name = "White Rum"},//3
//                new IngredientBase { Name = "Dark Rum"},//4
//                new IngredientBase { Name = "Orange Curaçao"},//5
//                new IngredientBase { Name = "Orgeat Syrup"},//6
//                new IngredientBase { Name = "Lime Juice"},//7
//                new IngredientBase { Name = "Tequila"},//8
//                new IngredientBase { Name = "Vodka"},//9
//                new IngredientBase { Name = "Gomme Syrup" },//10
//                new IngredientBase { Name = "Triple Sec" },//11
//                new IngredientBase { Name = "Gin"},//12
//                new IngredientBase { Name = "Lemon Juice"},//13
//                new IngredientBase { Name = "Coke"},//14
//                new IngredientBase { Name = "Sugar Syrup"},//15
//                new IngredientBase { Name = "Sparkling Water"},//16
//                new IngredientBase { Name = "Pisco"},//17
//                new IngredientBase { Name = "Egg White"}//18
//            };

//            var ingredients = new Ingredient[]
//            {
//                new Ingredient { IngredientBase = IngredientBases[0], Volume = 5, Dosage="cl"},//0                
//                new Ingredient { IngredientBase = IngredientBases[1], Volume = 1/2, Dosage = "cut into 4 wedges" },//1
//                new Ingredient { IngredientBase = IngredientBases[2], Volume = 2, Dosage = "teaspoons" },//2        
                
//                new Ingredient { IngredientBase = IngredientBases[3], Volume = 4, Dosage = "cl" },//3
//                new Ingredient { IngredientBase = IngredientBases[4], Volume = 2, Dosage = "cl" },//4
//                new Ingredient { IngredientBase = IngredientBases[5], Volume = 1.5, Dosage = "cl" },//5
//                new Ingredient { IngredientBase = IngredientBases[6], Volume = 1.5, Dosage = "cl" },//6
//                new Ingredient { IngredientBase = IngredientBases[7], Volume = 1, Dosage = "cl" },//7   
                
//                new Ingredient { IngredientBase = IngredientBases[8], Volume = 1.5, Dosage = "cl" },//8
//                new Ingredient { IngredientBase = IngredientBases[9], Volume = 1.5, Dosage = "cl" },//9
//                new Ingredient { IngredientBase = IngredientBases[3], Volume = 1.5, Dosage = "cl" },//10
//                new Ingredient { IngredientBase = IngredientBases[10], Volume = 3, Dosage = "cl" },//11
//                new Ingredient { IngredientBase = IngredientBases[11], Volume = 1.5, Dosage = "cl" },//12
//                new Ingredient { IngredientBase = IngredientBases[12], Volume = 1.5, Dosage = "cl" },//13
//                new Ingredient { IngredientBase = IngredientBases[13], Volume = 2.5, Dosage = "cl" },//14
//                new Ingredient { IngredientBase = IngredientBases[14], Volume = 1, Dosage = "dash" },//15    
                
//                new Ingredient { IngredientBase = IngredientBases[12], Volume = 4.5, Dosage = "cl" },//16
//                new Ingredient { IngredientBase = IngredientBases[13], Volume = 3, Dosage = "cl" },//17
//                new Ingredient { IngredientBase = IngredientBases[15], Volume = 1.5, Dosage = "cl" },//18
//                new Ingredient { IngredientBase = IngredientBases[16], Volume = 6, Dosage = "cl" },//19   
                
//                new Ingredient { IngredientBase = IngredientBases[17], Volume = 4.5, Dosage = "cl" },//20
//                new Ingredient { IngredientBase = IngredientBases[7], Volume = 3, Dosage = "cl" },//21
//                new Ingredient { IngredientBase = IngredientBases[15], Volume = 2, Dosage = "cl" },//22
//                new Ingredient { IngredientBase = IngredientBases[18], Volume = 1, Dosage = "0" }//23
//            };

//            var Origins = new Origin[]
//            {
//                new Origin { Country = "Brazil"},
//                new Origin { Country = "United States"},
//                new Origin { Country = "United Kingdom"},
//                new Origin { Country = "Peru"}
//            };

//            var Cocktails = new Cocktail[]
//            {
//                new Cocktail { Name = "Caipirinha", Origin = Origins[0]},
//                new Cocktail { Name = "Mai-Thai", Origin = Origins[1]},
//                new Cocktail { Name = "Long island ice tea", Origin = Origins[1]},
//                new Cocktail { Name = "John Collins", Origin = Origins[2]},
//                new Cocktail { Name = "Pisco Sour", Origin = Origins[3]}
//            };

//            var CocktailIngredients = new CocktailIngredient[]
//            {
//                new CocktailIngredient{ Cocktail = Cocktails[0], Ingredient = ingredients[0]},
//                new CocktailIngredient{ Cocktail = Cocktails[0], Ingredient = ingredients[1]},
//                new CocktailIngredient{ Cocktail = Cocktails[0], Ingredient = ingredients[2]},

//                new CocktailIngredient{ Cocktail = Cocktails[1], Ingredient = ingredients[3]},
//                new CocktailIngredient{ Cocktail = Cocktails[1], Ingredient = ingredients[4]},
//                new CocktailIngredient{ Cocktail = Cocktails[1], Ingredient = ingredients[5]},
//                new CocktailIngredient{ Cocktail = Cocktails[1], Ingredient = ingredients[6]},
//                new CocktailIngredient{ Cocktail = Cocktails[1], Ingredient = ingredients[7]},

//                new CocktailIngredient{ Cocktail = Cocktails[2], Ingredient = ingredients[8]},
//                new CocktailIngredient{ Cocktail = Cocktails[2], Ingredient = ingredients[9]},
//                new CocktailIngredient{ Cocktail = Cocktails[2], Ingredient = ingredients[10]},
//                new CocktailIngredient{ Cocktail = Cocktails[2], Ingredient = ingredients[11]},
//                new CocktailIngredient{ Cocktail = Cocktails[2], Ingredient = ingredients[12]},
//                new CocktailIngredient{ Cocktail = Cocktails[2], Ingredient = ingredients[13]},
//                new CocktailIngredient{ Cocktail = Cocktails[2], Ingredient = ingredients[14]},
//                new CocktailIngredient{ Cocktail = Cocktails[2], Ingredient = ingredients[15]},

//                new CocktailIngredient{ Cocktail = Cocktails[3], Ingredient = ingredients[16]},
//                new CocktailIngredient{ Cocktail = Cocktails[3], Ingredient = ingredients[17]},
//                new CocktailIngredient{ Cocktail = Cocktails[3], Ingredient = ingredients[18]},
//                new CocktailIngredient{ Cocktail = Cocktails[3], Ingredient = ingredients[19]},

//                new CocktailIngredient{ Cocktail = Cocktails[4], Ingredient = ingredients[20]},
//                new CocktailIngredient{ Cocktail = Cocktails[4], Ingredient = ingredients[21]},
//                new CocktailIngredient{ Cocktail = Cocktails[4], Ingredient = ingredients[22]},
//                new CocktailIngredient{ Cocktail = Cocktails[4], Ingredient = ingredients[23]}
//            };

//            context.Cocktails.AddRange(Cocktails);
//            context.Set<CocktailIngredient>().AddRange(CocktailIngredients);
//            context.SaveChanges();
//        }
//    }
//}
