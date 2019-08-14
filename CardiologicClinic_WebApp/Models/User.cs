using System.ComponentModel.DataAnnotations;

namespace CardiologicClinic_WebApp.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Imię użytkownika")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Nazwisko użytkownika")]
        public string UserSurname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Rola użytkownika")]
        public string UserRole { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
