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

        public async Task<CocktailDetailed> GetDetailed(int id)
        {
            return await db.Cocktails.Where(c => c.Id == id)
                .ProjectTo<CocktailDetailed>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            //return await db.Cocktails
            //    .Include(c => c.Origin)
            //    .Include(c => c.Ingredients)
            //    .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
