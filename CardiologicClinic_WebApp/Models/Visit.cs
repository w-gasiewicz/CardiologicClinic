using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
