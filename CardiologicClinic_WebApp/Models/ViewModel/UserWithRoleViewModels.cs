using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardiologicClinic_WebApp.Controllers
{
    public class UserWithRoleViewModels
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
