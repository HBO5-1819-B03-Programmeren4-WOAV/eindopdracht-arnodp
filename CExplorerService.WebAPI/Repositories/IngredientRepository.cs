﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CExplorerService.lib.DTO;
using CExplorerService.lib.Models;
using CExplorerService.WebAPI.Data;
using CExplorerService.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
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
            return await db.Ingredients
                .Where(i => i.CocktailId == id)
                .ProjectTo<IngredientBasic>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<IngredientBasicWithId>> GetAllIngredientsBasicid()
        {
            return await db.Ingredients.ProjectTo<IngredientBasicWithId>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
