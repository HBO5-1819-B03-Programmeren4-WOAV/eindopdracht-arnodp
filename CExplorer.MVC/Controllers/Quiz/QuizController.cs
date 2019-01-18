using CExplorer.MVC.Helpers;
using CExplorerService.lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace CExplorer.MVC.Controllers.Quiz
{
    public class QuizController : Controller
    {
        readonly string baseuri = "https://localhost:44385/api/Quiz";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuizStart()
        {
            return View();
        }
    }
}