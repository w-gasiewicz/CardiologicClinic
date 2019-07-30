using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        }

        [BindProperty]
        public InputModel Input { get; set; }
    }
}
