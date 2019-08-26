using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using HearAttackRecognition_ML.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardiologicClinic_WebApp.Models
{
    public class HeartDataInputModel : PageModel
    {
        public float result;
        public bool isIll;

        public class InputModel
        {
            [Required]
            [Display(Name = "Wiek")]
            public float Age { get; set; }
            [Required]
            [Display(Name = "Płeć")]
            public bool Sex { get; set; }
            [Required]
            [Display(Name = "Lokalizacja bólu")]
            public float PainLocation { get; set; }
            [Required]
            [Display(Name = "Promieniowanie bólu klatki piersiowej")]
            public float ChestPainRadiation { get; set; }
            [Required]
            [Display(Name = "Charakterystyka bólu")]
            public float PainCharacter { get; set; }
            [Required]
            [Display(Name = "Początek bólu")]
            public float OnsetOfPain { get; set; }
            [Required]
            [Display(Name = "Liczba godzin od nadejścia bólu")]
            public float NumOfHoursSinceOnset { get; set; }
            [Required]
            [Display(Name = "Czas trwania ostatniego bólu")]
            public float DurationOfTheLastEpisode { get; set; }
            [Required]
            [Display(Name = "Mdłości")]
            public bool Nausea { get; set; }
            [Required]
            [Display(Name = "Diaforeza")]
            public bool Diaphoresis { get; set; }
            [Required]
            [Display(Name = "Palpitacje")]
            public bool Palpitations { get; set; }
            [Required]
            [Display(Name = "Duszności")]
            public bool Dyspnea { get; set; }
            [Required]
            [Display(Name = "Zawroty głowy")]
            public bool Dizziness { get; set; }
            [Required]
            [Display(Name = "Bekanie??????????")]
            public bool Burping { get; set; }
            [Required]
            [Display(Name = "Czynniki łagodzące")]
            public float PalliativeFactors { get; set; }

            //history of similar pain
            [Required]
            [Display(Name = "Występowanie podobnych bóli w przeszłości")]
            public float PriorChestPainOfThisType { get; set; }
            [Required]
            [Display(Name = "Konsultacja z lekarzem z powodu poprzednich bóli")]
            public float PhysicianConsultedForPriorPain { get; set; }
            [Required]
            [Display(Name = "Wcześniejszy ból związany z sercem")]
            public float PriorPainRelatedToHeart { get; set; }
            [Required]
            [Display(Name = "Wcześniejszy ból związany z zawałem serca")]
            public float PriorPainDueToMI { get; set; }
            [Required]
            [Display(Name = "Wcześniejszy ból związany z chorobą niedokrwienną serca")]
            public float PriorPainDueToAnginaPectoris { get; set; }

            //Past Medical History 
            [Display(Name = "Zawał serca")]
            public float PriorMI { get; set; }
            [Display(Name = "Choroba niedokrwienna serca")]
            public float PriorAnginaPectoris { get; set; }
            [Display(Name = "Nietypowy ból w klatce piersiowej")]
            public float PriorAntypicalChestPain { get; set; }
            [Display(Name = "Niewydolność serca")]
            public float CongestiveHeartFailure { get; set; }
            [Display(Name = "Choroby naczyń obwodowych")]
            public float PeripheralVascularFailure { get; set; }
            [Display(Name = "Przepuklina rozworu przełykowego")]
            public float HiatalHernia { get; set; }
            [Display(Name = "Nadciśnienie")]
            public float Hypertension { get; set; }
            [Display(Name = "Cukrzyca")]
            public float Diabetes { get; set; }
            [Display(Name = "Palacz")]
            public float Smoker { get; set; }

            // Current Medication Usage
            [Display(Name = "Leki moczopędne")]
            public float Diuretics { get; set; }
            [Display(Name = "Azotany")]
            public float Nitrates { get; set; }
            [Display(Name = "Beta bloker")]
            public float BetaBlockers { get; set; }
            [Display(Name = "Naparstnica")]
            public float Digitalis { get; set; }
            [Display(Name = "Niesterydowy przeciwzapalny")]
            public float Nonsteroidal { get; set; }
            [Display(Name = "Związek zobojętniający kwasy")]
            public float Antacids { get; set; }

            //Physical Examinations
            [Display(Name = "Skurczowe ciśnienie krwi")]
            public float SystolicBloodPressure { get; set; }
            [Display(Name = "Rozkurczowe ciśnienie krwi")]
            public float DiastolicBloodPressure { get; set; }
            [Display(Name = "Tętno")]
            public float HeartRate { get; set; }
            [Display(Name = "Częstotliwość oddechów na minutę")]
            public float RespirationRate { get; set; }
            [Display(Name = "Rzężenie")]
            public float Rales { get; set; }
            [Display(Name = "Sinica")]
            public float Cyanosis { get; set; }
            [Display(Name = "Bladość")]
            public float Pallor { get; set; }
            [Display(Name = "Szmer sercowy skurczowy")]
            public float SystolicMurmur { get; set; }
            [Display(Name = "Szmer sercowy rozkurczowy")]
            public float DiastolicMurmur { get; set; }
            [Display(Name = "Obrzęk")]
            public float Oedema { get; set; }
            [Display(Name = "S3Gallop")]
            public float S3Gallop { get; set; }
            [Display(Name = "S4Gallop")]
            public float S4Gallop { get; set; }
            [Display(Name = "Wrażliwość klatki piersiowej")]
            public float ChestWallTenderness { get; set; }
            [Display(Name = "Diaforeza")]
            public float DiaphoresisPE { get; set; }

            //ecg examination
            [Display(Name = "Nowy załamek Q")]
            public float NewQWave { get; set; }
            [Display(Name = "Załamek Q")]
            public float AnyQWave { get; set; }
            [Display(Name = "Nowy wzrost odcinka ST")]
            public float NewSTSegmentElevation { get; set; }
            [Display(Name = "Wzrost odcinka ST")]
            public float AnySTSegmentElevation { get; set; }
            [Display(Name = "Nowy spadek odcinka ST")]
            public float NewSTSegmentDepression { get; set; }
            [Display(Name = "Spadek odcinka ST")]
            public float AnySTSegmentDepression { get; set; }
            [Display(Name = "Nowa inwersja załamka T")]
            public float NewTWaveInversion { get; set; }
            [Display(Name = "Tnwersja załamka T")]
            public float AnyTWaveInversion { get; set; }
            [Display(Name = "Nowy błąd przewodnictwa międzykomorowego")]
            public float NewIntraventricularConductionDefect { get; set; }
            [Display(Name = "Błąd przewodnictwa międzykomorowego")]
            public float AnyIntraventricularConductionDefect { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [HttpPost]
        public void LoadAIData()
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
                Nausea = Input.Nausea? 1 : 0,
                Diaphoresis = Input.Diaphoresis? 1 : 0,
                Palpitations = Input.Palpitations? 1:0,
                Dyspnea = Input.Dyspnea? 1:0,
                Dizziness = Input.Dizziness? 1:0,
                Burping = Input.Burping? 1:0,
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
        }

        public async Task<IActionResult> OnPostAsync()
        {
            int x = 0;

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
            return Page();
        }

    }
}
