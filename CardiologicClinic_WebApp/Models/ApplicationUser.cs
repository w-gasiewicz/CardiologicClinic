using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CardiologicClinic_WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Imię użytkownika")]
        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko użytkownika")]
        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string UserSurname { get; set; }
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Rola jest wymagana.")]
        public string Role { get; set; }
    }
}
