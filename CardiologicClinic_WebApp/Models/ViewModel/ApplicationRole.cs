using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardiologicClinic_WebApp.Models.ViewModel
{
    public class ApplicationRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
