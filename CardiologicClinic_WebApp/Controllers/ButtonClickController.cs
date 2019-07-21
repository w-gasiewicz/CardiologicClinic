using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeartAtackRecognition_AI.Procedures;
using Microsoft.AspNetCore.Mvc;

namespace CardiologicClinic_WebApp.Controllers
{
    public class ButtonClickController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Check(string button)
        {
            TempData["test"]="test";
            LoadFiles loader = new LoadFiles();
            loader.OpenFile();
            return View();
        }
    }
}