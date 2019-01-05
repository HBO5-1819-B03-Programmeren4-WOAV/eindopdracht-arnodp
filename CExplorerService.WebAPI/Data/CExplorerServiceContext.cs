using CExplorerService.lib.Models;
using Microsoft.EntityFrameworkCore;

namespace CExplorerService.WebAPI.Data
{
    public class CExplorerServiceContext : DbContext
    {
        public CExplorerServiceContext(DbContextOptions<CExplorerServiceContext> options) : base(options)
        {
        }

        public DbSet<IngredientBase> IngredientBases { get; set; }
        public DbSet<Origin> Origins { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<QuestionBase> QuestionBases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region commentary
            //modelBuilder.Entity<IngredientBase>().ToTable("IngredientBase")
            //    .HasData(
            //    new IngredientBase { Name = "Cachaça",Id = 1 },
            //    new IngredientBase { Name = "Lime", Id = 2 },
            //    new IngredientBase { Name = "Sugar",Id = 3 },
            //    new IngredientBase { Name = "White Rum",Id = 4 },
            //    new IngredientBase { Name = "Dark Rum",Id = 5 },
            //    new IngredientBase { Name = "Orange Curaçao",Id = 6 },
            //    new IngredientBase { Name = "Orgeat Syrup", Id = 7 },
            //    new IngredientBase { Name = "Lime Juice", Id = 8 },
            //    new IngredientBase { Name = "Tequila", Id = 9 },
            //    new IngredientBase { Name = "Vodka", Id = 10 },
            //    new IngredientBase { Name = "Gomme Syrup", Id = 11 },
            //    new IngredientBase { Name = "Triple Sec", Id = 12 },
            //    new IngredientBase { Name = "Gin", Id = 13 },
            //    new IngredientBase { Name = "Lemon Juice", Id = 14 },
            //    new IngredientBase { Name = "Coke", Id = 15 },
            //    new IngredientBase { Name = "Sugar Syrup", Id = 16 },
            //    new IngredientBase { Name = "Sparkling Water", Id = 17 },
            //    new IngredientBase { Name = "Pisco", Id = 18 },
            //    new IngredientBase { Name = "Egg White",Id = 19 }
            //    );

            //modelBuilder.Entity<Ingredient>().ToTable("Ingredient").HasData(
            //    new Ingredient { Id = 1, IngredientBaseId = 1, Volume = 5, Dosage = "cl" },
            //    new Ingredient { Id = 2, IngredientBaseId = 2, Volume = 1 / 2, Dosage = "cut into 4 wedges" },
            //    new Ingredient { Id = 3, IngredientBaseId = 3, Volume = 2, Dosage = "teaspoons" },

            //    new Ingredient { Id = 4, IngredientBaseId = 4, Volume = 4, Dosage = "cl" },
            //    new Ingredient { Id = 5, IngredientBaseId = 5, Volume = 2, Dosage = "cl" },
            //    new Ingredient { Id = 6, IngredientBaseId = 6, Volume = 1.5, Dosage = "cl" },
            //    new Ingredient { Id = 7, IngredientBaseId = 7, Volume = 1.5, Dosage = "cl" },
            //    new Ingredient { Id = 8, IngredientBaseId = 8, Volume = 1, Dosage = "cl" },

            //    new Ingredient { Id = 9, IngredientBaseId = 9, Volume = 1.5, Dosage = "cl" },
            //    new Ingredient { Id = 10, IngredientBaseId = 10, Volume = 1.5, Dosage = "cl" },
            //    new Ingredient { Id = 11, IngredientBaseId = 4, Volume = 1.5, Dosage = "cl" },
            //    new Ingredient { Id = 12, IngredientBaseId = 11, Volume = 3, Dosage = "cl" },
            //    new Ingredient { Id = 13, IngredientBaseId = 12, Volume = 1.5, Dosage = "cl" },
            //    new Ingredient { Id = 14, IngredientBaseId = 13, Volume = 1.5, Dosage = "cl" },
            //    new Ingredient { Id = 15, IngredientBaseId = 14, Volume = 2.5, Dosage = "cl" },
            //    new Ingredient { Id = 16, IngredientBaseId = 15, Volume = 1, Dosage = "dash" },

            //    new Ingredient { Id = 17, IngredientBaseId = 13, Volume = 4.5, Dosage = "cl" },
            //    new Ingredient { Id = 18, IngredientBaseId = 14, Volume = 3, Dosage = "cl" },
            //    new Ingredient { Id = 19, IngredientBaseId = 16, Volume = 1.5, Dosage = "cl" },
            //    new Ingredient { Id = 20, IngredientBaseId = 17, Volume = 6, Dosage = "cl" },

            //    new Ingredient { Id = 21, IngredientBaseId = 18, Volume = 4.5, Dosage = "cl" },
            //    new Ingredient { Id = 22, IngredientBaseId = 8, Volume = 3, Dosage = "cl" },
            //    new Ingredient { Id = 23, IngredientBaseId = 16, Volume = 2, Dosage = "cl" },
            //    new Ingredient { Id = 24, IngredientBaseId = 19, Volume = 1, Dosage = "" }
            //    );

            //modelBuilder.Entity<Origin>().ToTable("Origin").HasData(
            //    new Origin { Country = "Brazil", Id = 1 },
            //    new Origin { Country = "United States", Id = 2 },
            //    new Origin { Country = "United Kingdom", Id = 3 },
            //    new Origin { Country = "Peru", Id = 4 }
            //    );

            //modelBuilder.Entity<Cocktail>().ToTable("Cocktail").HasData(
            //    new Cocktail { Name = "Caipirinha", OriginId = 1, Id = 1 },
            //    new Cocktail { Name = "Mai-Thai", OriginId = 2, Id = 2 },
            //    new Cocktail { Name = "Long island ice tea", OriginId = 2, Id = 3 },
            //    new Cocktail { Name = "John Collins", OriginId = 3, Id = 4 },
            //    new Cocktail { Name = "Pisco Sour", OriginId = 4, Id = 5 }
            //    );

            //modelBuilder.Entity<CocktailIngredient>().ToTable("CocktailIngredient").HasData(

            //    );
            #endregion

            modelBuilder.Entity<CocktailIngredient>()
                .HasKey(ci => new { ci.CocktailId, ci.IngredientId });

            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.CocktailsWithIngredients)
                .WithOne(ci => ci.Ingredient);

            modelBuilder.Entity<Cocktail>()
                .HasMany(c => c.CocktailIngredients)
                .WithOne(ci => ci.Cocktail);

            base.OnModelCreating(modelBuilder);
        }
    }
}
