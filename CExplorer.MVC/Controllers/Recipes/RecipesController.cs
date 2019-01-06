using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CExplorer.MVC.Helpers;
using CExplorerService.lib.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CExplorer.MVC.Controllers.Recipes
{
    public class RecipesController : Controller
    {
        readonly string baseuri = "https://localhost:44375/api/Recipes";
        public IActionResult Index()
        {
            string uri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<CocktailBasic>>(uri));
        }
    }
}