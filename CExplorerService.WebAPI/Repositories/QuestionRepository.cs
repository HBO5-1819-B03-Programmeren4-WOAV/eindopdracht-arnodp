using AutoMapper;
using CExplorerService.lib.Models;
using CExplorerService.lib.DTO;
using CExplorerService.WebAPI.Data;
using CExplorerService.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CExplorerService.WebAPI.Repositories
{
    public class QuestionRepository : MappingRepository<QuestionBase>
    {
        public QuestionRepository(CExplorerServiceContext context, IMapper mapper) : base(context, mapper)
        { }

        public async Task<QuestionBase> GetRandomQuestion ()
        {
            int max = db.QuestionBases.Count() +1;
            Random rnd = new Random();
            int rndQuestionId = rnd.Next(1, max);

            return await db.QuestionBases
                .Where(q => q.Id == rndQuestionId).FirstOrDefaultAsync();
        }
    }
}
