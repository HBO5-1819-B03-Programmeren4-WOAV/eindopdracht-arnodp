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

        public async Task<GuessCocktailData> GetGuessCocktailData()
        {
            GuessCocktailData questionData = new GuessCocktailData();
            Random rnd = new Random();

            //get random a random cocktail.
            int rndId = rnd.Next(1, (db.Cocktails.Count() + 1));

            var cocktail = await db.Cocktails.Where(c => c.Id == rndId)
                .Include(c => c.Ingredients)
                .ProjectTo<CocktailWithIngredients>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            //generate list with 3 random id's
            List<int> ids = new List<int>();
            while (ids.Count != 3)
            {
                rndId = rnd.Next(1, (db.Cocktails.Count() + 1));
                if (rndId != cocktail.Id)//rndId cannot be equile to the correct cocktail Id
                    ids.Add(rndId);
            }
            rndId = rnd.Next(0,3);
            ids.Insert(rndId, cocktail.Id);//add correct cocktail id in random position

            questionData.Answer1 = db.Cocktails.Where(c => c.Id == ids[0]).FirstOrDefaultAsync().Result.Name;
            questionData.Answer2 = db.Cocktails.Where(c => c.Id == ids[1]).FirstOrDefaultAsync().Result.Name;
            questionData.Answer3 = db.Cocktails.Where(c => c.Id == ids[2]).FirstOrDefaultAsync().Result.Name;
            questionData.Answer4 = db.Cocktails.Where(c => c.Id == ids[3]).FirstOrDefaultAsync().Result.Name;

            questionData.cocktail = cocktail;

            return questionData;
        }

        public async Task<GuessIngredientData> GetGuessIngredientData()
        {
            GuessIngredientData questionData = new GuessIngredientData();
            Random rnd = new Random();

            //get random a random cocktail.
            int rndId = rnd.Next(1, (db.Cocktails.Count() + 1));

            var cocktail = await db.Cocktails.Where(c => c.Id == rndId)
                .Include(c => c.Ingredients)
            .ProjectTo<CocktailWithIngredients>(mapper.ConfigurationProvider).FirstOrDefaultAsync();

            //get list of ingredients for cocktail
            var ingredients = cocktail.Ingredients;
            
            //get random ingredient as correct answer.
            rndId = rnd.Next(1, (ingredients.Count()));
            var correctanswer = ingredients.ElementAt(rndId);
            
            //remove correct answer from list. (this list is going to be displayed )
            ingredients.Remove(correctanswer);
            
            //add list to cocktail
            cocktail.Ingredients = ingredients;
            
            //add necessary data to questiondata
            questionData.cocktail = cocktail;
            questionData.correctanswer = correctanswer.name;

            //
            var CA = await db.Ingredients
                .Where(i => i.Name == correctanswer.name).FirstOrDefaultAsync();

            //generate 3 random ingredients
            List<int> ids = new List<int>();
            while (ids.Count != 3)
            {
                rndId = rnd.Next(1, (db.Ingredients.Count() + 1));
                var random = await db.Ingredients.Where(i => i.Id == rndId).FirstOrDefaultAsync();

                if(random.Id != CA.Id)
                    ids.Add(rndId);
            }

            //insert correct answer id into random postion
            rndId = rnd.Next(0, 3);
            ids.Insert(rndId, CA.Id);
            
            //set answers
            questionData.Answer1 = db.Ingredients.Where(i => i.Id == ids[0])
                                .ProjectTo<IngredientBasic>(mapper.ConfigurationProvider).FirstOrDefaultAsync().Result.name;

            questionData.Answer2 = db.Ingredients.Where(i => i.Id == ids[1])
                                .ProjectTo<IngredientBasic>(mapper.ConfigurationProvider).FirstOrDefaultAsync().Result.name;

            questionData.Answer3 = db.Ingredients.Where(i => i.Id == ids[2])
                                .ProjectTo<IngredientBasic>(mapper.ConfigurationProvider).FirstOrDefaultAsync().Result.name;

            questionData.Answer4 = db.Ingredients.Where(i => i.Id == ids[3])
                                .ProjectTo<IngredientBasic>(mapper.ConfigurationProvider).FirstOrDefaultAsync().Result.name;

            return questionData;
        }

        public async Task<GuessOriginData> GetGuessOriginData()
        {
            GuessOriginData questionData = new GuessOriginData();
            Random rnd = new Random();

            //get random a random cocktail.
            int rndId = rnd.Next(1, (db.Cocktails.Count() + 1));

            var cocktail = await db.Cocktails.Where(c => c.Id == rndId)
                .Include(c => c.Origin)
            .ProjectTo<CocktailWithOrigin>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
            
            //get random origin ids
            List<int> ids = new List<int>();
            while (ids.Count != 3)
            {
                rndId = rnd.Next(1, (db.Origins.Count()));
                var rndOrigin = await db.Origins.Where(o => o.Id == rndId).FirstOrDefaultAsync();

                if (rndOrigin.Country != cocktail.Origin)
                    ids.Add(rndId);
            }
            
            //get id correct origin and insert into ids list
            var CO = await db.Origins.Where(o => o.Country == cocktail.Origin).FirstOrDefaultAsync();
            rndId = rnd.Next(0, 3);
            ids.Insert(rndId, CO.Id);
            
            //set questiondata
            questionData.cocktail = cocktail;

            questionData.Answer1 = db.Origins.Where(o => o.Id == ids[0]).FirstOrDefaultAsync().Result.Country;
            questionData.Answer2 = db.Origins.Where(o => o.Id == ids[1]).FirstOrDefaultAsync().Result.Country;
            questionData.Answer3 = db.Origins.Where(o => o.Id == ids[2]).FirstOrDefaultAsync().Result.Country;
            questionData.Answer4 = db.Origins.Where(o => o.Id == ids[3]).FirstOrDefaultAsync().Result.Country;

            return questionData;
        }
    }
}
