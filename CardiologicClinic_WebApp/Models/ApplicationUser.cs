using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CardiologicClinic_WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Imię użytkownika")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko użytkownika")]
        public string UserSurname { get; set; }
    }
}
