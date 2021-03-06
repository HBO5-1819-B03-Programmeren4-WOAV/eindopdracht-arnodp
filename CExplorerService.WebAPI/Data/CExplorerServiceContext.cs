﻿using CExplorerService.lib.Models;
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
            modelBuilder.Entity<Origin>().ToTable("Origins").HasData(
                new Origin { Country = "Brazil", Id = 1 },
                new Origin { Country = "United States", Id = 2 },
                new Origin { Country = "United Kingdom", Id = 3 },
                new Origin { Country = "Peru", Id = 4 }
                );

            modelBuilder.Entity<Cocktail>().ToTable("Cocktails").HasData(
                new Cocktail { Name = "Caipirinha", OriginId = 1, Id = 1 },
                new Cocktail { Name = "Mai-Thai", OriginId = 2, Id = 2 },
                new Cocktail { Name = "Long island ice tea", OriginId = 2, Id = 3 },
                new Cocktail { Name = "John Collins", OriginId = 3, Id = 4 },
                new Cocktail { Name = "Pisco Sour", OriginId = 4, Id = 5 }
                );

            modelBuilder.Entity<IngredientBase>().ToTable("IngredientBase")
                .HasData(
                new IngredientBase { Name = "Cachaça", Id = 1 },
                new IngredientBase { Name = "Lime", Id = 2 },
                new IngredientBase { Name = "Sugar", Id = 3 },
                new IngredientBase { Name = "White Rum", Id = 4 },
                new IngredientBase { Name = "Dark Rum", Id = 5 },
                new IngredientBase { Name = "Orange Curaçao", Id = 6 },
                new IngredientBase { Name = "Orgeat Syrup", Id = 7 },
                new IngredientBase { Name = "Lime Juice", Id = 8 },
                new IngredientBase { Name = "Tequila", Id = 9 },
                new IngredientBase { Name = "Vodka", Id = 10 },
                new IngredientBase { Name = "Gomme Syrup", Id = 11 },
                new IngredientBase { Name = "Triple Sec", Id = 12 },
                new IngredientBase { Name = "Gin", Id = 13 },
                new IngredientBase { Name = "Lemon Juice", Id = 14 },
                new IngredientBase { Name = "Coke", Id = 15 },
                new IngredientBase { Name = "Sugar Syrup", Id = 16 },
                new IngredientBase { Name = "Sparkling Water", Id = 17 },
                new IngredientBase { Name = "Pisco", Id = 18 },
                new IngredientBase { Name = "Egg White", Id = 19 }
                );

            modelBuilder.Entity<Ingredient>().ToTable("Ingredients").HasData(
                new Ingredient {Name = "Cachaça", CocktailId = 1, Id = 1,  Volume = 5, Dosage = "cl" },
                new Ingredient {Name = "Lime", CocktailId = 1, Id = 2,  Volume = .5, Dosage = "cut into 4 wedges" },
                new Ingredient {Name = "Sugar", CocktailId = 1, Id = 3,  Volume = 2, Dosage = "teaspoons" },

                new Ingredient {Name = "White Rum", CocktailId = 2, Id = 4,  Volume = 4, Dosage = "cl" },
                new Ingredient {Name = "Dark Rum", CocktailId = 2, Id = 5,  Volume = 2, Dosage = "cl" },
                new Ingredient {Name = "Orange Curaçao", CocktailId = 2, Id = 6,  Volume = 1.5, Dosage = "cl" },
                new Ingredient {Name = "Orgeat Syrup", CocktailId = 2, Id = 7,  Volume = 1.5, Dosage = "cl" },
                new Ingredient {Name = "Lime Juice", CocktailId = 2, Id = 8,  Volume = 1, Dosage = "cl" },

                new Ingredient {Name = "Tequila", CocktailId = 3, Id = 9,  Volume = 1.5, Dosage = "cl" },
                new Ingredient {Name = "Vodka", CocktailId = 3, Id = 10, Volume = 1.5, Dosage = "cl" },
                new Ingredient {Name = "White Rum", CocktailId = 3, Id = 11, Volume = 1.5, Dosage = "cl" },
                new Ingredient {Name = "Gomme Syrup", CocktailId = 3, Id = 12, Volume = 3, Dosage = "cl" },
                new Ingredient {Name = "Triple Sec", CocktailId = 3, Id = 13, Volume = 1.5, Dosage = "cl" },
                new Ingredient {Name = "Gin", CocktailId = 3, Id = 14, Volume = 1.5, Dosage = "cl" },
                new Ingredient {Name = "Lemon Juice", CocktailId = 3, Id = 15, Volume = 2.5, Dosage = "cl" },
                new Ingredient {Name = "Coke", CocktailId = 3, Id = 16, Volume = 1, Dosage = "dash" },

                new Ingredient {Name = "Gin", CocktailId = 4, Id = 17, Volume = 4.5, Dosage = "cl" },
                new Ingredient {Name = "Lemon Juice", CocktailId = 4, Id = 18, Volume = 3, Dosage = "cl" },
                new Ingredient {Name = "Sugar Syrup", CocktailId = 4, Id = 19, Volume = 1.5, Dosage = "cl" },
                new Ingredient {Name = "Sparkling Water", CocktailId = 4, Id = 20, Volume = 6, Dosage = "cl" },

                new Ingredient {Name = "Pisco", CocktailId = 5, Id = 21, Volume = 4.5, Dosage = "cl" },
                new Ingredient {Name = "Lime Juice", CocktailId = 5, Id = 22,Volume = 3, Dosage = "cl" },
                new Ingredient {Name = "Sugar Syrup", CocktailId = 5, Id = 23, Volume = 2, Dosage = "cl" },
                new Ingredient {Name = "Egg White", CocktailId = 5, Id = 24, Volume = 1, Dosage = "" }
                );

            modelBuilder.Entity<QuestionBase>().ToTable("Questions").HasData(
                new QuestionBase { Id = 1, Question = "Wich cocktail can you make with these ingredients ?", Partial = "GuessCocktail" },
                new QuestionBase { Id = 2, Question = "Wich ingredient is missing ?", Partial = "GuessIngredient" },
                new QuestionBase { Id = 3, Question = "What is the origin of this cocktail ?", Partial = "GuessOrigin" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
