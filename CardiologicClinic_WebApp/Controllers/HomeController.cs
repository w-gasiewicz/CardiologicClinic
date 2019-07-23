using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CardiologicClinic_WebApp.Models;
using CardiologicClinic_WebApp.AI.Procedures;
using CardiologicClinic_WebApp.AI;

namespace CardiologicClinic_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Opis przychodni kardiologicznej.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Strona kontaktowa.";

            return View();
        }

        public IActionResult HeartAttack()
        {
            ViewData["Message"] = "Moduł wykrywający zawał serca.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void LoadAIData()
        {
            RunAIAlgorythm start = new RunAIAlgorythm();
            start.RunAI();
        }
    }
}
