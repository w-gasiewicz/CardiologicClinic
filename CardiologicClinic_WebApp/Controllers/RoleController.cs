using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CardiologicClinic_WebApp.Controllers
{
    public class RoleController : Controller
    {
        IHttpContextAccessor httpContextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public RoleController() { }
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());//Return Roles
        }
        //Create is for View
        public IActionResult Create()
        {
            return View();
        }

        //Create is for Posting data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModels Role)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(Role.Name));//Add new Role
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                AddErrors(result);
            }
            return View(Role);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        private UserManager<IdentityUser> _userManager;
        public void CompetitionsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            var user = _userManager.GetUserAsync(HttpContext.User);
        }

        public void GetUserRole()
        {
            // var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.IsTestUser = User.FindFirst(ClaimTypes.Name).Value == "Admin";
            //return User.FindFirst(ClaimTypes.Name).Value;
        }
    }
}