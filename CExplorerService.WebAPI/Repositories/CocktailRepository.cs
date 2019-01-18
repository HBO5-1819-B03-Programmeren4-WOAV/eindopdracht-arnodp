using AutoMapper;
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
    public class CocktailRepository : MappingRepository<Cocktail>
    {
        public CocktailRepository(CExplorerServiceContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<List<Cocktail>> GetCocktailWithOrigin()
        {
            return (await db.Cocktails
                 .Include(c => c.Origin)
                 .ToListAsync());
        }

        public async Task<List<CocktailBasic>> ListBasic()
        {
            return await db.Cocktails.ProjectTo<CocktailBasic>(mapper.ConfigurationProvider)
                .OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<CocktailWithIngredients> GetRndWithIngredients()
        {
            Random rnd = new Random();
            int rndCId = rnd.Next(1,( db.Cocktails.Count() + 1));

            return await db.Cocktails.Where(c => c.Id == rndCId)
                .Include(c => c.Ingredients)
                .ProjectTo<CocktailWithIngredients>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<List<CocktailBasic>> GetRndBasicList(int id)
        {
            List<CocktailBasic> cocktailBasics = new List<CocktailBasic>();

            var correctanswer = await db.Cocktails
                .Where(c => c.Id == id).ProjectTo<CocktailBasic>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            Random rnd = new Random();
            int rndint = rnd.Next(1, (db.Cocktails.Count() + 1));

            while (cocktailBasics.Count != 3)
            {
                var newcocktail = await db.Cocktails
                     .Where(c => c.Id == rndint).ProjectTo<CocktailBasic>(mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync();

                if (newcocktail != correctanswer)
                    cocktailBasics.Add(newcocktail);

                rndint = rnd.Next(1, (db.Cocktails.Count() + 1));
            }

            rndint = rnd.Next(1, (cocktailBasics.Count() + 1));
            cocktailBasics.Insert(rndint, correctanswer);

            return cocktailBasics;
        }
    }
}
