using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardiologicClinic_WebApp.Areas.Identity.Pages.Account.Manage
{
    public class UsersManagementModel : PageModel
    {
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

    //    public async Task OnGetAsync(string sortOrder)
    //    {
    //        NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
    //        DateSort = sortOrder == "Date" ? "date_desc" : "Date";

    //        IQueryable<u> userIQ = from s in _context.Users
    //                                        select s;

    //        switch (sortOrder)
    //        {
    //            case "name_desc":
    //                userIQ = userIQ.OrderByDescending(s => s.LastName);
    //                break;
    //            case "Date":
    //                userIQ = userIQ.OrderBy(s => s.EnrollmentDate);
    //                break;
    //            case "date_desc":
    //                userIQ = userIQ.OrderByDescending(s => s.EnrollmentDate);
    //                break;
    //            default:
    //                userIQ = userIQ.OrderBy(s => s.LastName);
    //                break;
    //        }

    //        Student = await studentIQ.AsNoTracking().ToListAsync();
    //    }
    }
}