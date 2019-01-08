using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CExplorerService.lib.Models;
using CExplorerService.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetIngredientsBasic()
        {
            return Ok(await repository.GetIngredientsBasic());
        }
    }
}