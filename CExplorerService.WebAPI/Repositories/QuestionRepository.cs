using AutoMapper;
using CExplorerService.lib.Models;
using CExplorerService.lib.DTO;
using CExplorerService.WebAPI.Data;
using CExplorerService.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;

namespace CExplorerService.WebAPI.Repositories
{
    public class QuestionRepository : MappingRepository<QuestionBase>
    {
        public QuestionRepository(CExplorerServiceContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<QuestionBase> GetRandomQuestion()
        {
            int max = db.QuestionBases.Count() + 1;
            Random rnd = new Random();
            int rndId = rnd.Next(1, max);

            return await db.QuestionBases
                .Where(q => q.Id == rndId).FirstOrDefaultAsync();
        }

        public async Task<QuestionData> GetGuessCocktailData()
        {
            QuestionData questionData = new QuestionData();
            Random rnd = new Random();

            //get random a random cocktail.
            int rndId = rnd.Next(1, (db.Cocktails.Count() + 1));

            var cocktailWithIngredients = await db.Cocktails.Where(c => c.Id == rndId)
                .Include(c => c.Ingredients)
                .ProjectTo<CocktailWithIngredients>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            //generate list with 3 random id's
            List<int> ids = new List<int>();
            while (ids.Count != 3)
            {
                rndId = rnd.Next(1, (db.Cocktails.Count() + 1));
                if (rndId != cocktailWithIngredients.Id)//rndId cannot be equile to the correct cocktail Id
                    ids.Add(rndId);
            }
            rndId = rnd.Next(0,3);
            ids.Insert(rndId, cocktailWithIngredients.Id);//add correct cocktail id in random position

            questionData.Answer1 = db.Cocktails.Where(c => c.Id == ids[0]).FirstOrDefaultAsync().Result.Name;
            questionData.Answer2 = db.Cocktails.Where(c => c.Id == ids[1]).FirstOrDefaultAsync().Result.Name;
            questionData.Answer3 = db.Cocktails.Where(c => c.Id == ids[2]).FirstOrDefaultAsync().Result.Name;
            questionData.Answer4 = db.Cocktails.Where(c => c.Id == ids[3]).FirstOrDefaultAsync().Result.Name;

            questionData.cocktailWithIngredients = cocktailWithIngredients;

            return questionData;
        }
    }
}
