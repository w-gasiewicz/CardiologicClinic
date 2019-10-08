using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardiologicClinic_WebApp.Data;
using CardiologicClinic_WebApp.Models;
using System;
using System.Collections.Generic;
using CardiologicClinic_WebApp.Areas.Identity.Services;

namespace CardiologicClinic_WebApp.Controllers
{
    public class VisitsController : Controller
    {
        public static List<ApplicationUser> patients;

        private readonly ApplicationDbContext _context;

        public VisitsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Visits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visit.ToListAsync());
        }

        public async Task<IActionResult/*List<ApplicationUser>*/> Search(string sortOrder, string searchString)
        {
            List<Visit> toReturn = new List<Visit>();
            var visits = from s in _context.Visit
                         select s;

            patients = new List<ApplicationUser>();
            patients = _context.ApplicationUser.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                patients.RemoveAll(u => !u.UserName.ToUpper().Contains(searchString.ToUpper()) && !u.UserSurname.ToUpper().Contains(searchString.ToUpper()));

                var visitsList = visits.ToList();

                foreach (var patient in patients)
                {
                    toReturn.AddRange(visitsList.FindAll(v => v.IdPatient == patient.Id));
                }
            }
            return View(toReturn);
        }

        public string GetUser(string id)
        {
            VisitService vs = new VisitService();
            return vs.GetSpecificUser(id);
        }

        // GET: Visits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // GET: Visits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPatient,IdDoctor,VisitDate,VisitName,Price")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                var patientVisits = _context.Visit.Where(v => v.IdPatient == visit.IdPatient).ToList();
                var doctorVisits = _context.Visit.Where(v => v.IdDoctor == visit.IdDoctor).ToList();

                patientVisits.RemoveAll(v => v.VisitDate.AddHours(-1) > visit.VisitDate || v.VisitDate.AddHours(1) < visit.VisitDate);
                doctorVisits.RemoveAll(v => v.VisitDate.AddHours(-1) > visit.VisitDate || v.VisitDate.AddHours(1) < visit.VisitDate);

                if (patientVisits.Count == 0 && doctorVisits.Count == 0)
                {
                    _context.Add(visit);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return Redirect("/Identity/Account/Manage/VisitExist");
            }
            return View(visit);
        }

        // GET: Visits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visit.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,IdPatient,IdDoctor,VisitDate,VisitName")] Visit visit)
        {
            if (id != visit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitExists(visit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(visit);
        }

        // GET: Visits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var visit = await _context.Visit.FindAsync(id);
            _context.Visit.Remove(visit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitExists(string id)
        {
            return _context.Visit.Any(e => e.Id == id);
        }
    }
}
