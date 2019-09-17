using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardiologicClinic_WebApp.Data;
using CardiologicClinic_WebApp.Models;
using System;
using Microsoft.AspNetCore.Identity;

namespace CardiologicClinic_WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult/*List<ApplicationUser>*/> Search(string sortOrder, string searchString)
        {
            var users = from s in _context.ApplicationUser
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.UserSurname.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            return View (await users.AsNoTracking().ToListAsync());
        }
        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        } 
        // GET: Users/Details/5
        public async Task<IActionResult> DoctorDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,UserSurname,Email,Password,PhoneNumber,Role")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var userNew = new ApplicationUser { UserName = user.Email, Email = user.Email, Name = user.Name, PhoneNumber = user.PhoneNumber };
                var result = await _userManager.CreateAsync(userNew, user.Password);
                await _userManager.AddToRoleAsync(userNew, user.Role);
                await _context.SaveChangesAsync();
                return Redirect("/Identity/Account/Manage/UserView");
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,UserSurname,Email,PhoneNumber,Role")] ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var orgUser = await _context.ApplicationUser.FindAsync(id);

                    if (user.Name != String.Empty)
                        orgUser.Name = user.Name;
                    if (user.UserSurname != String.Empty)
                        orgUser.UserSurname = user.UserSurname;
                    if (user.Email != String.Empty)
                        orgUser.Email = user.Email;
                    if (user.PhoneNumber != String.Empty)
                        orgUser.PhoneNumber = user.PhoneNumber;

                    if (orgUser.Role != user.Role)
                    {
                        if (await _userManager.IsInRoleAsync(orgUser, "Recepcion"))
                            await _userManager.RemoveFromRoleAsync(orgUser, "Recepcion");
                        if (await _userManager.IsInRoleAsync(orgUser, "Admin"))
                            await _userManager.RemoveFromRoleAsync(orgUser, "Admin");
                        if (await _userManager.IsInRoleAsync(orgUser, "Doctor"))
                            await _userManager.RemoveFromRoleAsync(orgUser, "Doctor");
                        if (await _userManager.IsInRoleAsync(orgUser, "User"))
                            await _userManager.RemoveFromRoleAsync(orgUser, "User");
                        if (await _userManager.IsInRoleAsync(orgUser, user.Role))
                            await _userManager.RemoveFromRoleAsync(orgUser, user.Role);
                        await _userManager.AddToRoleAsync(orgUser, user.Role);
                    }

                    _context.Entry(orgUser).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Identity/Account/Manage/UserView");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.ApplicationUser.FindAsync(id);
            _context.ApplicationUser.Remove(user);
            await _context.SaveChangesAsync();
            return Redirect("/Identity/Account/Manage/UserView"); 
        }

        private bool UserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
