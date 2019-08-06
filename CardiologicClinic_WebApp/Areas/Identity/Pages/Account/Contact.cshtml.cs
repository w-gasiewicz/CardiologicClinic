using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace CardiologicClinic_WebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactInput Contact { get; set; }

        public class ContactInput
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            public string Message { get; set; }
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("gasiewicz.wojciech@gmail.com", "dzierio01928"),
                        EnableSsl = true
                    };
                    client.Send("gasiewicz.wojciech@gmail.com", "gasiewicz.wojciech@gmail.com", "wiadomość z kliniki kardiologicznej", 
                        Contact.Message + "\n Wiadomośc od: " + Contact.Name + " " + Contact.LastName + "\n Email:" + Contact.Email);
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                }
            }
            ModelState.Clear();
            Contact.Name = String.Empty;
            Contact.LastName = String.Empty;
            Contact.Message = String.Empty;
            Contact.Email = String.Empty;
            return Page();
        }
    }
}
