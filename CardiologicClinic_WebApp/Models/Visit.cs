using System;
using System.ComponentModel.DataAnnotations;

namespace CardiologicClinic_WebApp.Models
{
    public class Visit
    {
        public string Id { get; set; }
        [Display(Name = "Pacjent")]
        public string IdPatient { get; set; }
        [Display(Name = "Lekarz")]
        public string IdDoctor { get; set; }
        [Display(Name = "Data wizyty")]
        [Required(ErrorMessage = "Data wizyty jest wymagana.")]
        public DateTime VisitDate { get; set; }
        [Display(Name = "Nazwa wizyty")]
        public string VisitName { get; set; }
        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena jest wymagana.")]
        public float Price { get; set; }
        [Display(Name = "Notatka lekarza")]        
        public string VisitNote { get; set; }
    }
}
