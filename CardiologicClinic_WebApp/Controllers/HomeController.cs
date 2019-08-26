using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CardiologicClinic_WebApp.Models;
using CardiologicClinic_WebApp.Models;
using HearAttackRecognition_ML.Models;

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

        public IActionResult PriceList()
        {
            return View();
        }

        public IActionResult Timeline()
        {
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

        //public void LoadAIData()
        //{
        //    int x = 0;
        //    HeartData userData = new HeartData()
        //    {
        //        Age = 21,
        //        Sex = 0,
        //        PainLocation = 7,
        //        ChestPainRadiation = 1,
        //        PainCharacter = 1,
        //        OnsetOfPain = 3,
        //        NumOfHoursSinceOnset = 15,
        //        DurationOfTheLastEpizode = 6,
        //        Nausea = 0,
        //        Diaphoresis = 0,
        //        Palpitations = 0,
        //        Dyspnea = 1,
        //        Dizziness = 0,
        //        Burping = 1,
        //        PallativeFactors = 1,
        //        PriorChestPainOfThisType = 1,
        //        PhysicianConsultedForPriorPain = 0,
        //        PriorPainRelatedToHeart = 0,
        //        PriorPainDueToMI = 0,
        //        PriorPainDueToAnginaPectoris = 0,
        //        PriorMI = 0,
        //        PriorAnginaPectoris = 1,
        //        PriorAntypicalChestPain = 1,
        //        CongestiveHeartFailure = 1,
        //        PeripheralVascularFailure = 0,
        //        HiatalHernia = 0,
        //        Hypertension = 1,
        //        Diabetes = 1,
        //        Smoker = 1,
        //        Diuretics = 0,
        //        Nitrates = 1,
        //        BetaBlockers = 1,
        //        Digitalis = 0,
        //        Nonsteroidal = 0,
        //        Antacids = 0,
        //        SystolicBloodPressure = 157,
        //        DiastolicBloodPressure = 89,
        //        HeartRate = 76,
        //        RespirationRate = 21,
        //        Rales = 0,
        //        Cyanosis = 0,
        //        Pallor = 0,
        //        SystolicMurmur = 0,
        //        DiastolicMurmur = 0,
        //        Oedema = 0,
        //        S3Gallop = 0,
        //        S4Gallop = 1,
        //        ChestWallTenderness = 1,
        //        DiaphoresisPE = 1,
        //        NewQWave = 1,
        //        AnyQWave = 0,
        //        NewSTSegmentElevation = 0,
        //        AnySTSegmentElevation = 1,
        //        NewSTSegmentDepression = 1,
        //        AnySTSegmentDepression = 0,
        //        NewTWaveInversion = 0,
        //        AnyTWaveInversion = 0,
        //        NewIntraventricularConductionDefect = 0,
        //        AnyIntraventricularConductionDefect = 0
        //    };
        //    RunAI.Run();

        //    RunAIAlgorythm start = new RunAIAlgorythm();
        //    start.RunAI();
        //}
    }
}
