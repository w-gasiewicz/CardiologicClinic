using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CardiologicClinic_WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CardiologicClinic_WebApp.Controllers
{
    public class UserController : Controller
    {
        UserManager<IdentityUser> _UserManager;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<string> GetUserNameAsync(ClaimsPrincipal user)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            //var blog1 = context.Users.Where(b => b. == "ADO.NET Blog")
            //                   .Include(b => b.Posts)
            //                   .FirstOrDefault();
            var currentUser = await _UserManager.GetUserAsync(User);
            //var displayName = currentUser.;
            string name = user.FindFirst(ClaimTypes.Name).Value;
            return name;
        }
    }
}