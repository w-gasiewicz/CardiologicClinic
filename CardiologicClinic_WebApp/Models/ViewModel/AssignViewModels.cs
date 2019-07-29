using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardiologicClinic_WebApp.Controllers
{
    public class AssignViewModels
    {
        public string UserId { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
