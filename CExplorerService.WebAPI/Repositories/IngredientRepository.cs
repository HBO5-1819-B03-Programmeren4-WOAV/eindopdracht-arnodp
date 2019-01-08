﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CExplorerService.lib.DTO;
using CExplorerService.lib.Models;
using CExplorerService.WebAPI.Data;
using CExplorerService.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CExplorerService.WebAPI.Repositories
{
    public class IngredientRepository : MappingRepository<Ingredient>
    {
        public IngredientRepository (CExplorerServiceContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<List<IngredientBasic>> GetAllIngredientsBasic()
        {
            return await db.Ingredients.ProjectTo<IngredientBasic>(mapper.ConfigurationProvider)
                .OrderBy(i => i.name).ToListAsync();
        }
        public async Task<List<IngredientBasic>> GetIngredientsBasic(int id)
        {
            var test = await db.Ingredients
                .Where(i => i.CocktailId == id)
                .ProjectTo<IngredientBasic>(mapper.ConfigurationProvider)
                .ToListAsync();

            return test;

            //return mapper.Map<IngredientBasic>(
            //    await db.Ingredients
            //    .FirstOrDefaultAsync(i => i.CocktailId == id));
        }
    }
}
