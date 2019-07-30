using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CardiologicClinic_WebApp.Models.ViewModel
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
