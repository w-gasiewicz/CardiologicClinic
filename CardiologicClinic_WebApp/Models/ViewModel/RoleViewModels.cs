using System.ComponentModel.DataAnnotations;

namespace CardiologicClinic_WebApp.Controllers
{
    public class RoleViewModels
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
