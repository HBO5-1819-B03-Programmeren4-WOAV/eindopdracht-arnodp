using System.Threading.Tasks;
using CExplorerService.lib.Models;
using CExplorerService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CExplorerService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerCrudBase<Ingredient, IngredientRepository>
    {
        public IngredientsController(IngredientRepository ingredientRepository) : base(ingredientRepository)
        { }
        [HttpGet]
        [Route("basic")]
        public async Task<IActionResult> GetAllIngredientsBasic()
        {
            return Ok(await repository.GetAllIngredientsBasic());
        }

        [HttpGet]
        [Route("basic/{id}")]
        public async Task<IActionResult> GetIngredientsBasic(int id)
        {
            return Ok(await repository.GetIngredientsBasic(id));
        }
    }
}