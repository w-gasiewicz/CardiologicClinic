using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CardiologicClinic_WebApp.Models;
using CardiologicClinic_WebApp.Views.Home;
using System.IO;
using System;
using CardiologicClinic_WebApp.AI;

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
            ManagementAI ai = new ManagementAI();
            string predict = Input.Age.ToString() + ";" + (Input.Sex ? 1 : 0).ToString() + ";" + Input.PainLocation.ToString() + ";" + Input.ChestPainRadiation.ToString()
                + ";" + Input.PainCharacter.ToString() + ";" + Input.OnsetOfPain.ToString() + ";" + Input.NumOfHoursSinceOnset.ToString()
                + ";" + Input.DurationOfTheLastEpisode.ToString() + ";" + (Input.Nausea ? 1 : 0).ToString() + ";" + (Input.Diaphoresis ? 1 : 0).ToString()
                + ";" + (Input.Palpitations ? 1 : 0).ToString() + ";" + (Input.Dyspnea ? 1 : 0).ToString() + ";" + (Input.Dizziness ? 1 : 0).ToString()
                + ";" + (Input.Burping ? 1 : 0).ToString() + ";" + Input.PalliativeFactors.ToString() + ";" + Input.PriorChestPainOfThisType.ToString()
                + ";" + Input.PhysicianConsultedForPriorPain.ToString() + ";" + Input.PriorPainRelatedToHeart.ToString() + ";" + Input.PriorPainDueToMI.ToString()
                + ";" + Input.PriorPainDueToAnginaPectoris.ToString() + ";" + Input.PriorMI.ToString() + ";" + Input.PriorAnginaPectoris.ToString()
                + ";" + Input.PriorAntypicalChestPain.ToString() + ";" + Input.CongestiveHeartFailure.ToString() + ";" + Input.PeripheralVascularFailure.ToString()
                + ";" + Input.HiatalHernia.ToString() + ";" + Input.Hypertension.ToString() + ";" + Input.Diabetes.ToString() + ";" + Input.Smoker.ToString()
                + ";" + Input.Diuretics.ToString() + ";" + Input.Nitrates.ToString() + ";" + Input.BetaBlockers.ToString() + ";" + Input.Digitalis.ToString()
                + ";" + Input.Nonsteroidal.ToString() + ";" + Input.Antacids.ToString() + ";" + Input.SystolicBloodPressure.ToString() + ";" + Input.DiastolicBloodPressure.ToString()
                + ";" + Input.HeartRate.ToString() + ";" + Input.RespirationRate.ToString() + ";" + Input.Rales.ToString() + ";" + Input.Cyanosis.ToString()
                + ";" + Input.Pallor.ToString() + ";" + Input.SystolicMurmur.ToString() + ";" + Input.DiastolicMurmur.ToString() + ";" + Input.Oedema.ToString()
                + ";" + Input.S3Gallop.ToString() + ";" + Input.S4Gallop.ToString() + ";" + Input.ChestWallTenderness.ToString() + ";" + Input.DiaphoresisPE.ToString()
                + ";" + Input.NewQWave.ToString() + ";" + Input.AnyQWave.ToString() + ";" + Input.NewSTSegmentElevation.ToString() + ";" + Input.AnySTSegmentElevation.ToString()
                + ";" + Input.NewSTSegmentDepression.ToString() + ";" + Input.AnySTSegmentDepression.ToString() + ";" + Input.NewTWaveInversion.ToString()
                + ";" + Input.AnyTWaveInversion.ToString() + ";" + Input.NewIntraventricularConductionDefect.ToString() + ";" + Input.AnyIntraventricularConductionDefect.ToString();
            using (StreamWriter wr = new StreamWriter("./AI/predict.txt"))
            {
                wr.WriteLine(predict);
            }

            ai.Predict();

            string outData;
            using (StreamReader wr = new StreamReader("./AI/output.txt"))
            {
                outData=wr.ReadLine();
            }
            string[] tokens = outData.Split(';');
            //fill result to display
            HeartAttackModel.illness = Convert.ToInt32(tokens[0]);
            tokens[1] = tokens[1].Replace('.',',');
            HeartAttackModel.result = Convert.ToSingle(tokens[1]);
            HeartAttackModel.result = Convert.ToSingle(Math.Round(HeartAttackModel.result, 2));
            return View();
        }
    }
}
