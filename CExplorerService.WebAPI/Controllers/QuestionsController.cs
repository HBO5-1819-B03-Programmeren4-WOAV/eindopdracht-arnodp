using System.Threading.Tasks;
using CExplorerService.lib.Models;
using CExplorerService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CExplorerService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerCrudBase<QuestionBase, QuestionRepository>
    {
        public QuestionsController(QuestionRepository questionRepository) : base(questionRepository)
        { }

        [HttpGet]
        [Route("random")]
        public async Task<IActionResult> GetRandomQuestion()
        {
          return Ok( await repository.GetRandomQuestion());
        }

        //use partial in cshtml to make route ? remove if else struct

        [HttpGet]
        [Route("guesscocktail")]
        public async Task<IActionResult> GetGuessCocktailData()
        {
            return Ok(await repository.GetGuessCocktailData());
        }

        [HttpGet]
        [Route("guessingredients")]
        public async Task<IActionResult> GetGuessIngredientsData()
        {
            //todo repo method
            return Ok(await repository.GetGuessCocktailData());
        }

        [HttpGet]
        [Route("guessorigin")]
        public async Task<IActionResult> GetGuessOriginData()
        {
            //todo repo method
            return Ok(await repository.GetGuessCocktailData());
        }
    }
}