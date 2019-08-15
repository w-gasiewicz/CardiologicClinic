using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardiologicClinic_WebApp.Data;
using CardiologicClinic_WebApp.Models;
using System.Collections.Generic;
using System;

namespace CardiologicClinic_WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ApplicationUser>> Search(string sortOrder, string searchString)
        {
            var users = from s in _context.ApplicationUser
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.UserSurname.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }
            return await users.AsNoTracking().ToListAsync();
        }
            // GET: Users
            public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUser.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("UserName,UserSurname,Email,Password,PhoneNumber")] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
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
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,UserSurname,Email,PhoneNumber")] ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Attach(user);
                    if (user.Name != String.Empty)
                        _context.Entry(user).Property("Name").IsModified = true;
                    if (user.UserSurname != String.Empty)
                        _context.Entry(user).Property("UserSurname").IsModified = true;
                    if (user.Email != String.Empty)
                        _context.Entry(user).Property("Email").IsModified = true;
                    if (user.PhoneNumber != String.Empty)
                        _context.Entry(user).Property("PhoneNumber").IsModified = true;
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
