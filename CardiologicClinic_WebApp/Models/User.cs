using System.ComponentModel.DataAnnotations;

namespace CardiologicClinic_WebApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
    }
}
