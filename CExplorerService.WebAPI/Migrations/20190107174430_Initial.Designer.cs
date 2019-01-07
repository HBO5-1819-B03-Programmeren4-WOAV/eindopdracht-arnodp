﻿// <auto-generated />
using CExplorerService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CExplorerService.WebAPI.Migrations
{
    [DbContext(typeof(CExplorerServiceContext))]
    [Migration("20190107174430_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CExplorerService.lib.Models.Cocktail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("OriginId");

                    b.HasKey("Id");

                    b.HasIndex("OriginId");

                    b.ToTable("Cocktail");

                    b.HasData(
                        new { Id = 1, Name = "Caipirinha", OriginId = 1 },
                        new { Id = 2, Name = "Mai-Thai", OriginId = 2 },
                        new { Id = 3, Name = "Long island ice tea", OriginId = 2 },
                        new { Id = 4, Name = "John Collins", OriginId = 3 },
                        new { Id = 5, Name = "Pisco Sour", OriginId = 4 }
                    );
                });

            modelBuilder.Entity("CExplorerService.lib.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CocktailId");

                    b.Property<string>("Dosage");

                    b.Property<int>("IngredientBaseId");

                    b.Property<double>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.HasIndex("IngredientBaseId");

                    b.ToTable("Ingredient");

                    b.HasData(
                        new { Id = 1, CocktailId = 1, Dosage = "cl", IngredientBaseId = 1, Volume = 5.0 },
                        new { Id = 2, CocktailId = 1, Dosage = "cut into 4 wedges", IngredientBaseId = 2, Volume = 0.0 },
                        new { Id = 3, CocktailId = 1, Dosage = "teaspoons", IngredientBaseId = 3, Volume = 2.0 },
                        new { Id = 4, CocktailId = 2, Dosage = "cl", IngredientBaseId = 4, Volume = 4.0 },
                        new { Id = 5, CocktailId = 2, Dosage = "cl", IngredientBaseId = 5, Volume = 2.0 },
                        new { Id = 6, CocktailId = 2, Dosage = "cl", IngredientBaseId = 6, Volume = 1.5 },
                        new { Id = 7, CocktailId = 2, Dosage = "cl", IngredientBaseId = 7, Volume = 1.5 },
                        new { Id = 8, CocktailId = 2, Dosage = "cl", IngredientBaseId = 8, Volume = 1.0 },
                        new { Id = 9, CocktailId = 3, Dosage = "cl", IngredientBaseId = 9, Volume = 1.5 },
                        new { Id = 10, CocktailId = 3, Dosage = "cl", IngredientBaseId = 10, Volume = 1.5 },
                        new { Id = 11, CocktailId = 3, Dosage = "cl", IngredientBaseId = 4, Volume = 1.5 },
                        new { Id = 12, CocktailId = 3, Dosage = "cl", IngredientBaseId = 11, Volume = 3.0 },
                        new { Id = 13, CocktailId = 3, Dosage = "cl", IngredientBaseId = 12, Volume = 1.5 },
                        new { Id = 14, CocktailId = 3, Dosage = "cl", IngredientBaseId = 13, Volume = 1.5 },
                        new { Id = 15, CocktailId = 3, Dosage = "cl", IngredientBaseId = 14, Volume = 2.5 },
                        new { Id = 16, CocktailId = 3, Dosage = "dash", IngredientBaseId = 15, Volume = 1.0 },
                        new { Id = 17, CocktailId = 4, Dosage = "cl", IngredientBaseId = 13, Volume = 4.5 },
                        new { Id = 18, CocktailId = 4, Dosage = "cl", IngredientBaseId = 14, Volume = 3.0 },
                        new { Id = 19, CocktailId = 4, Dosage = "cl", IngredientBaseId = 16, Volume = 1.5 },
                        new { Id = 20, CocktailId = 4, Dosage = "cl", IngredientBaseId = 17, Volume = 6.0 },
                        new { Id = 21, CocktailId = 5, Dosage = "cl", IngredientBaseId = 18, Volume = 4.5 },
                        new { Id = 22, CocktailId = 5, Dosage = "cl", IngredientBaseId = 8, Volume = 3.0 },
                        new { Id = 23, CocktailId = 5, Dosage = "cl", IngredientBaseId = 16, Volume = 2.0 },
                        new { Id = 24, CocktailId = 5, Dosage = "", IngredientBaseId = 19, Volume = 1.0 }
                    );
                });

            modelBuilder.Entity("CExplorerService.lib.Models.IngredientBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("IngredientBase");

                    b.HasData(
                        new { Id = 1, Name = "Cachaça" },
                        new { Id = 2, Name = "Lime" },
                        new { Id = 3, Name = "Sugar" },
                        new { Id = 4, Name = "White Rum" },
                        new { Id = 5, Name = "Dark Rum" },
                        new { Id = 6, Name = "Orange Curaçao" },
                        new { Id = 7, Name = "Orgeat Syrup" },
                        new { Id = 8, Name = "Lime Juice" },
                        new { Id = 9, Name = "Tequila" },
                        new { Id = 10, Name = "Vodka" },
                        new { Id = 11, Name = "Gomme Syrup" },
                        new { Id = 12, Name = "Triple Sec" },
                        new { Id = 13, Name = "Gin" },
                        new { Id = 14, Name = "Lemon Juice" },
                        new { Id = 15, Name = "Coke" },
                        new { Id = 16, Name = "Sugar Syrup" },
                        new { Id = 17, Name = "Sparkling Water" },
                        new { Id = 18, Name = "Pisco" },
                        new { Id = 19, Name = "Egg White" }
                    );
                });

            modelBuilder.Entity("CExplorerService.lib.Models.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.HasKey("Id");

                    b.ToTable("Origin");

                    b.HasData(
                        new { Id = 1, Country = "Brazil" },
                        new { Id = 2, Country = "United States" },
                        new { Id = 3, Country = "United Kingdom" },
                        new { Id = 4, Country = "Peru" }
                    );
                });

            modelBuilder.Entity("CExplorerService.lib.Models.QuestionBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Question");

                    b.HasKey("Id");

                    b.ToTable("QuestionBases");
                });

            modelBuilder.Entity("CExplorerService.lib.Models.Cocktail", b =>
                {
                    b.HasOne("CExplorerService.lib.Models.Origin", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CExplorerService.lib.Models.Ingredient", b =>
                {
                    b.HasOne("CExplorerService.lib.Models.Cocktail", "Cocktail")
                        .WithMany("Ingredients")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CExplorerService.lib.Models.IngredientBase", "IngredientBase")
                        .WithMany()
                        .HasForeignKey("IngredientBaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
