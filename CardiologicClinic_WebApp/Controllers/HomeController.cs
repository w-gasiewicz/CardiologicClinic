using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CardiologicClinic_WebApp.Models;
using HearAttackRecognition_ML.Models;
using CardiologicClinic_WebApp.Views.Home;
using System.IO;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System;

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

            //ScriptEngine engine = Python.CreateEngine();
            //var searchPaths = engine.GetSearchPaths();
            //engine.SetSearchPaths(searchPaths);
            //searchPaths.Add(@"C:\Users\FUJITSU\Anaconda3\Lib\site-packages\tensorflow\_api\v1\compat\v1\keras");
            //engine.ExecuteFile("./AI/xd.py");

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\FUJITSU\PycharmProjects\NIDUC\venv\Scripts\python.exe";
            start.Arguments = string.Format("./AI/setup.py");
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    int x = 0;
                }
            }

            //string fileName = "./AI/xd.py";
            //Process p = new Process();
            //p.StartInfo = new ProcessStartInfo(@"C:\Users\FUJITSU\PycharmProjects\NIDUC\venv\Scripts\python.exe", fileName)
            //{
            //    RedirectStandardOutput = true
            //};
            //p.Start();

            //string output = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();

            //string outputText = string.Empty;
            //string standardError = string.Empty;
            //try
            //{
            //    using (Process process = new Process())
            //    {
            //        process.StartInfo = new ProcessStartInfo("./AI/xd.py")
            //        {
            //            Arguments = "./AI/xd.py",
            //            UseShellExecute = false,
            //            RedirectStandardOutput = true,
            //            RedirectStandardError = true,
            //            CreateNoWindow = true
            //        };
            //        process.Start();
            //        outputText = process.StandardOutput.ReadToEnd();
            //        outputText = outputText.Replace(Environment.NewLine, string.Empty);
            //        standardError = process.StandardError.ReadToEnd();
            //        process.WaitForExit();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string exceptionMessage = ex.Message;
            //}
            //int x = 0;

            //exe try:
            //string fileName = "./AI/main.py";
            //string path = "C:/Users/FUJITSU/source/repos/CardiologicClinic_WebApp/CardiologicClinic_WebApp/AI";
            //Process p = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = "/c \"python " + path + "\\main.py\"";
            //p.StartInfo = startInfo;
            //p.Start();
            //int x = 0;

            //HeartData userData = new HeartData()
            //{
            //    Age = Input.Age,
            //    Sex = Input.Sex ? 1 : 0,
            //    PainLocation = Input.PainLocation,
            //    ChestPainRadiation = Input.ChestPainRadiation,
            //    PainCharacter = Input.PainCharacter,
            //    OnsetOfPain = Input.OnsetOfPain,
            //    NumOfHoursSinceOnset = Input.NumOfHoursSinceOnset,
            //    DurationOfTheLastEpizode = Input.DurationOfTheLastEpisode,
            //    Nausea = Input.Nausea ? 1 : 0,
            //    Diaphoresis = Input.Diaphoresis ? 1 : 0,
            //    Palpitations = Input.Palpitations ? 1 : 0,
            //    Dyspnea = Input.Dyspnea ? 1 : 0,
            //    Dizziness = Input.Dizziness ? 1 : 0,
            //    Burping = Input.Burping ? 1 : 0,
            //    PallativeFactors = Input.PalliativeFactors,
            //    PriorChestPainOfThisType = Input.PriorChestPainOfThisType,
            //    PhysicianConsultedForPriorPain = Input.PhysicianConsultedForPriorPain,
            //    PriorPainRelatedToHeart = Input.PriorPainRelatedToHeart,
            //    PriorPainDueToMI = Input.PriorPainDueToMI,
            //    PriorPainDueToAnginaPectoris = Input.PriorPainDueToAnginaPectoris,
            //    PriorMI = Input.PriorMI,
            //    PriorAnginaPectoris = Input.PriorAnginaPectoris,
            //    PriorAntypicalChestPain = Input.PriorAntypicalChestPain,
            //    CongestiveHeartFailure = Input.CongestiveHeartFailure,
            //    PeripheralVascularFailure = Input.PeripheralVascularFailure,
            //    HiatalHernia = Input.HiatalHernia,
            //    Hypertension = Input.Hypertension,
            //    Diabetes = Input.Diabetes,
            //    Smoker = Input.Smoker,
            //    Diuretics = Input.Diuretics,
            //    Nitrates = Input.Nitrates,
            //    BetaBlockers = Input.BetaBlockers,
            //    Digitalis = Input.Digitalis,
            //    Nonsteroidal = Input.Nonsteroidal,
            //    Antacids = Input.Antacids,
            //    SystolicBloodPressure = Input.SystolicBloodPressure,
            //    DiastolicBloodPressure = Input.DiastolicBloodPressure,
            //    HeartRate = Input.HeartRate,
            //    RespirationRate = Input.RespirationRate,
            //    Rales = Input.Rales,
            //    Cyanosis = Input.Cyanosis,
            //    Pallor = Input.Pallor,
            //    SystolicMurmur = Input.SystolicMurmur,
            //    DiastolicMurmur = Input.DiastolicMurmur,
            //    Oedema = Input.Oedema,
            //    S3Gallop = Input.S3Gallop,
            //    S4Gallop = Input.S4Gallop,
            //    ChestWallTenderness = Input.ChestWallTenderness,
            //    DiaphoresisPE = Input.DiaphoresisPE,
            //    NewQWave = Input.NewQWave,
            //    AnyQWave = Input.AnyQWave,
            //    NewSTSegmentElevation = Input.NewSTSegmentElevation,
            //    AnySTSegmentElevation = Input.AnySTSegmentElevation,
            //    NewSTSegmentDepression = Input.NewSTSegmentDepression,
            //    AnySTSegmentDepression = Input.AnySTSegmentDepression,
            //    NewTWaveInversion = Input.NewTWaveInversion,
            //    AnyTWaveInversion = Input.AnyTWaveInversion,
            //    NewIntraventricularConductionDefect = Input.NewIntraventricularConductionDefect,
            //    AnyIntraventricularConductionDefect = Input.AnyIntraventricularConductionDefect
            //};
            ////RunAI.Run();
            //RunAI.Test(userData);
            //HeartAttackModel.result = RunAI.result;
            //HeartAttackModel.isIll = RunAI.isIll;

            return View();
        }
    }
}
