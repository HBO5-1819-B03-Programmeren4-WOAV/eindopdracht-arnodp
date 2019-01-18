using Microsoft.AspNetCore.Mvc;

namespace CExplorer.MVC.Controllers.Quiz
{
    public class QuizController : Controller
    {
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