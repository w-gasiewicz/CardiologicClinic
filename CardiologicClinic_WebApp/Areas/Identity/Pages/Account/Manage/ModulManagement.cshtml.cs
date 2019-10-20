using System;
using CardiologicClinic_WebApp.AI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardiologicClinic_WebApp.Areas.Identity.Pages.Account.Manage
{
    public class ModulManagementModel : PageModel
    {
        public int iterations;
        public float result;

        public IActionResult OnGet(int iterations)
        {
            ManagementAI ai = new ManagementAI();
            string prevAcc = ai.GetActualAcc();
            ai.Training(iterations);
            string newAcc = ai.GetActualAcc();
            result = Convert.ToSingle(newAcc) - Convert.ToSingle(prevAcc);
            result = Convert.ToSingle(Math.Round(result, 2));
            return Page();
        }
    }
}