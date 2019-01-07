using AutoMapper;
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
    public class CocktailRepository : MappingRepository<Cocktail>
    {
        public CocktailRepository(CExplorerServiceContext context, IMapper mapper) : base(context, mapper)
        { }


        public async Task<List<Cocktail>> GetAllInclusive()
        {
           var test = await db.Cocktails
                .Include(c => c.Origin)
                .ToListAsync();
            return test;
        }


            public async Task<List<CocktailBasic>> ListBasic()
        {
            var cocktails = await db.Cocktails.Select(c => new CocktailBasic
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync();

            return cocktails;

            //return await db.Cocktails.ProjectTo<CocktailBasic>(mapper.ConfigurationProvider)
            //    .OrderBy(c => c.Name).ToListAsync();
        }
    }
}
