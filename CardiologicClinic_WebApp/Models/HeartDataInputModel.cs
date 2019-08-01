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
            public int Age { get; set; }
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
    }
}
