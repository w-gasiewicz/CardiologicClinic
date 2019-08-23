using System;
using System.ComponentModel.DataAnnotations;

namespace CardiologicClinic_WebApp.Models
{
    public class Visit
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string IdPatient { get; set; }
        [Required]
        public string IdDoctor { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
        [Required]
        public string VisitName { get; set; }

    }
}
