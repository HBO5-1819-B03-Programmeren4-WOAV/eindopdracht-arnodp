using System.Threading.Tasks;
using CExplorerService.lib.Models;
using CExplorerService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CExplorerService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerCrudBase<Cocktail,CocktailRepository>
    {
        public RecipesController(CocktailRepository cocktailRepository): base(cocktailRepository)
        {
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }

        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetCocktailBasic()
        {
            var cocktails = await repository.ListBasic();
            return Ok(cocktails);
        }
    }
}