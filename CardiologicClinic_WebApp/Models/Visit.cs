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
        public DateTime VisitDate { get; set; }
        [Display(Name = "Nazwa wizyty")]
        public string VisitName { get; set; }
        [Display(Name = "Cena")]
        //[Required(ErrorMessage = "Cena musi być liczbą")]
        public float Price { get; set; }

    }
}
