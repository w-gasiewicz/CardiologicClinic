using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CardiologicClinic_WebApp.Models
{
    public class HeartDataInputModel
    {
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
            public int PainLocation { get; set; }
            [Required]
            [Display(Name = "Promieniowanie bólu klatki piersiowej")]
            public int ChestPainRadiation { get; set; }
            [Required]
            [Display(Name = "Charakterystyka bólu")]
            public int PainCharacter { get; set; }
            [Required]
            [Display(Name = "Początek bólu")]
            public int OnsetOfPain { get; set; }
            [Required]
            [Display(Name = "Liczba godzin od nadejścia bólu")]
            public int NumOfHoursSinceOnset { get; set; }
            [Required]
            [Display(Name = "Czas trwania ostatniego bólu")]
            public int DurationOfTheLastEpisode { get; set; }
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
            public int PalliativeFactors { get; set; }
            [Required]
            [Display(Name = "Występowanie podobnych dolegliwości w przeszłości")]
            public int HistoryOfSimilarPain { get; set; }
            [Required]
            [Display(Name = "Historia choroby")]
            public int PastMedicalHistory { get; set; }
            [Required]
            [Display(Name = "Aktualnie stosowaneL leki")]
            public int CurrentMedicationUsage { get; set; }
            [Required]
            [Display(Name = "Badanie lekarskie")]
            public int PhysicalExaminations { get; set; }
            [Required]
            [Display(Name = "Badanie EKG")]
            public int EcgExamination { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void LoadAIData()
        {
            HearAttackRecognition_ML.Models.HeartData userData = new HearAttackRecognition_ML.Models.HeartData()
            {
                Age = Input.Age,
                Sex = Input.Sex ? 1 : 0,
                PainLocation = 7,
                ChestPainRadiation = 1,
                PainCharacter = 1,
                OnsetOfPain = 3,
                NumOfHoursSinceOnset = 15,
                DurationOfTheLastEpizode = 6,
                Nausea = 0,
                Diaphoresis = 0,
                Palpitations = 0,
                Dyspnea = 1,
                Dizziness = 0,
                Burping = 1,
                PallativeFactors = 1,
                PriorChestPainOfThisType = 1,
                PhysicianConsultedForPriorPain = 0,
                PriorPainRelatedToHeart = 0,
                PriorPainDueToMI = 0,
                PriorPainDueToAnginaPectoris = 0,
                PriorMI = 0,
                PriorAnginaPectoris = 1,
                PriorAntypicalChestPain = 1,
                CongestiveHeartFailure = 1,
                PeripheralVascularFailure = 0,
                HiatalHernia = 0,
                Hypertension = 1,
                Diabetes = 1,
                Smoker = 1,
                Diuretics = 0,
                Nitrates = 1,
                BetaBlockers = 1,
                Digitalis = 0,
                Nonsteroidal = 0,
                Antacids = 0,
                SystolicBloodPressure = 157,
                DiastolicBloodPressure = 89,
                HeartRate = 76,
                RespirationRate = 21,
                Rales = 0,
                Cyanosis = 0,
                Pallor = 0,
                SystolicMurmur = 0,
                DiastolicMurmur = 0,
                Oedema = 0,
                S3Gallop = 0,
                S4Gallop = 1,
                ChestWallTenderness = 1,
                DiaphoresisPE = 1,
                NewQWave = 1,
                AnyQWave = 0,
                NewSTSegmentElevation = 0,
                AnySTSegmentElevation = 1,
                NewSTSegmentDepression = 1,
                AnySTSegmentDepression = 0,
                NewTWaveInversion = 0,
                AnyTWaveInversion = 0,
                NewIntraventricularConductionDefect = 0,
                AnyIntraventricularConductionDefect = 0
            };
            HearAttackRecognition_ML.Models.RunAI.Run();
        }
    }
}
