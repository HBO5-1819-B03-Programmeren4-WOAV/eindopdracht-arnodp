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
    [Migration("20190104193207_InitialCreate")]
    partial class InitialCreate
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

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("CExplorerService.lib.Models.CocktailIngredient", b =>
                {
                    b.Property<int>("CocktailId");

                    b.Property<int>("IngredientId");

                    b.HasKey("CocktailId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CocktailIngredient");
                });

            modelBuilder.Entity("CExplorerService.lib.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dosage");

                    b.Property<int>("IngredientBaseId");

                    b.Property<double>("Volume");

                    b.HasKey("Id");

                    b.HasIndex("IngredientBaseId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CExplorerService.lib.Models.IngredientBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("IngredientBases");
                });

            modelBuilder.Entity("CExplorerService.lib.Models.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.HasKey("Id");

                    b.ToTable("Origins");
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

            modelBuilder.Entity("CExplorerService.lib.Models.CocktailIngredient", b =>
                {
                    b.HasOne("CExplorerService.lib.Models.Cocktail", "Cocktail")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("CocktailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CExplorerService.lib.Models.Ingredient", "Ingredient")
                        .WithMany("CocktailsWithIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CExplorerService.lib.Models.Ingredient", b =>
                {
                    b.HasOne("CExplorerService.lib.Models.IngredientBase", "IngredientBase")
                        .WithMany()
                        .HasForeignKey("IngredientBaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
