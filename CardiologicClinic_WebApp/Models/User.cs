using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CardiologicClinic_WebApp.Models
{
    public class User
    {
        public string Id { get; set; }
        [Display(Name = "Imię użytkownika")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko użytkownika")]
        public string UserSurname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Rola użytkownika")]
        public string UserRole { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }
    }
}
