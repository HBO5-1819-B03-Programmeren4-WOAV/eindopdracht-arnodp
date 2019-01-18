using System.Threading.Tasks;
using CExplorerService.lib.Models;
using CExplorerService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CExplorerService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerCrudBase<QuestionBase, QuestionRepository>
    {
        public QuizController(QuestionRepository questionRepository) : base(questionRepository)
        { }

        [HttpGet]
        [Route("random")]
        public async Task<IActionResult> GetRandomQuestion()
        {
            return Ok(await repository.GetRandomQuestion());
        }

    }
}