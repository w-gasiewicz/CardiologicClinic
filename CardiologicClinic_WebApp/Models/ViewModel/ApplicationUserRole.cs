using CardiologicClinic_WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardiologicClinic_WebApp.Models.ViewModel
{
    public class ApplicationUserRole
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
