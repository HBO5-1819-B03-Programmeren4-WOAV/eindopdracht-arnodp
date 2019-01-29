using System.Threading.Tasks;
using CExplorerService.lib.Models;
using CExplorerService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CExplorerService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailsController : ControllerCrudBase<Cocktail,CocktailRepository>
    {
        public CocktailsController(CocktailRepository cocktailRepository): base(cocktailRepository)
        {
        }

        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetCocktailWithOrigin());
        }

        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetCocktailBasic()
        {
            return Ok(await repository.ListBasic());
        }

        [HttpGet]
        [Route("random")]
        public async Task<IActionResult> GetRndCocktailWithIngredients()
        {
            return Ok(await repository.GetRndWithIngredients());
        }

        [HttpGet]
        [Route("randomlist/{id}")]
        public async Task<IActionResult> GetRndCocktailBasicList(int Id)
        {
            return Ok(await repository.GetRndBasicList(Id));
        }

        [HttpGet]
        [Route("detailed/{id}")]
        public async Task<IActionResult> GetDetailedCocktail (int id)
        {
            var test = await repository.GetDetailed(id);
            return Ok(test);
        }

        [HttpPut]
        [Route("test/{id}")]
        public async Task<IActionResult> Put([FromBody] Cocktail cocktail)
        {
            int x = 0;
            return await base.Post(cocktail);
        }

        [HttpPost]
        public async override Task<IActionResult> Post([FromBody] Cocktail cocktail )
        {

            return await base.Post(cocktail);
        }

    }
}