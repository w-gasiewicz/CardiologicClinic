using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CardiologicClinic_WebApp.Models;
using HearAttackRecognition_ML.Models;
using CardiologicClinic_WebApp.Views.Home;

namespace CardiologicClinic_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public float result;
        public bool isIll;

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

        public IActionResult Diagnosis(HeartAttackModel.InputModel Input)
        {
            HeartData userData = new HeartData()
            {
                Age = Input.Age,
                Sex = Input.Sex ? 1 : 0,
                PainLocation = Input.PainLocation,
                ChestPainRadiation = Input.ChestPainRadiation,
                PainCharacter = Input.PainCharacter,
                OnsetOfPain = Input.OnsetOfPain,
                NumOfHoursSinceOnset = Input.NumOfHoursSinceOnset,
                DurationOfTheLastEpizode = Input.DurationOfTheLastEpisode,
                Nausea = Input.Nausea ? 1 : 0,
                Diaphoresis = Input.Diaphoresis ? 1 : 0,
                Palpitations = Input.Palpitations ? 1 : 0,
                Dyspnea = Input.Dyspnea ? 1 : 0,
                Dizziness = Input.Dizziness ? 1 : 0,
                Burping = Input.Burping ? 1 : 0,
                PallativeFactors = Input.PalliativeFactors,
                PriorChestPainOfThisType = Input.PriorChestPainOfThisType,
                PhysicianConsultedForPriorPain = Input.PhysicianConsultedForPriorPain,
                PriorPainRelatedToHeart = Input.PriorPainRelatedToHeart,
                PriorPainDueToMI = Input.PriorPainDueToMI,
                PriorPainDueToAnginaPectoris = Input.PriorPainDueToAnginaPectoris,
                PriorMI = Input.PriorMI,
                PriorAnginaPectoris = Input.PriorAnginaPectoris,
                PriorAntypicalChestPain = Input.PriorAntypicalChestPain,
                CongestiveHeartFailure = Input.CongestiveHeartFailure,
                PeripheralVascularFailure = Input.PeripheralVascularFailure,
                HiatalHernia = Input.HiatalHernia,
                Hypertension = Input.Hypertension,
                Diabetes = Input.Diabetes,
                Smoker = Input.Smoker,
                Diuretics = Input.Diuretics,
                Nitrates = Input.Nitrates,
                BetaBlockers = Input.BetaBlockers,
                Digitalis = Input.Digitalis,
                Nonsteroidal = Input.Nonsteroidal,
                Antacids = Input.Antacids,
                SystolicBloodPressure = Input.SystolicBloodPressure,
                DiastolicBloodPressure = Input.DiastolicBloodPressure,
                HeartRate = Input.HeartRate,
                RespirationRate = Input.RespirationRate,
                Rales = Input.Rales,
                Cyanosis = Input.Cyanosis,
                Pallor = Input.Pallor,
                SystolicMurmur = Input.SystolicMurmur,
                DiastolicMurmur = Input.DiastolicMurmur,
                Oedema = Input.Oedema,
                S3Gallop = Input.S3Gallop,
                S4Gallop = Input.S4Gallop,
                ChestWallTenderness = Input.ChestWallTenderness,
                DiaphoresisPE = Input.DiaphoresisPE,
                NewQWave = Input.NewQWave,
                AnyQWave = Input.AnyQWave,
                NewSTSegmentElevation = Input.NewSTSegmentElevation,
                AnySTSegmentElevation = Input.AnySTSegmentElevation,
                NewSTSegmentDepression = Input.NewSTSegmentDepression,
                AnySTSegmentDepression = Input.AnySTSegmentDepression,
                NewTWaveInversion = Input.NewTWaveInversion,
                AnyTWaveInversion = Input.AnyTWaveInversion,
                NewIntraventricularConductionDefect = Input.NewIntraventricularConductionDefect,
                AnyIntraventricularConductionDefect = Input.AnyIntraventricularConductionDefect
            };
            RunAI.Run();
            RunAI.Test(userData);
            HeartAttackModel.result = RunAI.result;
            HeartAttackModel.isIll = RunAI.isIll;

            return View();
        }
    }
}
