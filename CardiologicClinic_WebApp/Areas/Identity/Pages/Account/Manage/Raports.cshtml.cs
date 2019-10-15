using System;
using System.Linq;
using System.Threading.Tasks;
using CardiologicClinic_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardiologicClinic_WebApp.Areas.Identity.Pages.Account.Manage
{
    public class RaportsModel : PageModel
    {
        public DateTime DataOd = DateTime.Now.Date.AddMonths(-1);
        public DateTime DataDo = DateTime.Now.Date;
        public int Rok;
        public float sum;
        public int qua;
        public string mostPopularDoctor;
        public int mostPopularDoctorCount;

        private readonly ApplicationDbContext _context;

        public RaportsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(DateTime DataOd, DateTime DataDo)
        {
            var visits = _context.Visit.Where(v => v.VisitDate.Date >= DataOd.Date && v.VisitDate.Date <= DataDo.Date).ToList();
            qua = 0;
            mostPopularDoctorCount = 0;

            if (visits.Count > 0)
            {
                var most = visits.GroupBy(i => i.IdDoctor).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                var count = visits.FindAll(v => v.IdDoctor == most).ToList();
                mostPopularDoctorCount = count.Count;
                var doctor = _context.ApplicationUser.FirstOrDefault(v => v.Id == most);
                mostPopularDoctor = doctor.Name + " " + doctor.UserSurname;
            }
            foreach (var visit in visits)
            {
                sum += visit.Price;
                qua++;
            }

            return null;
        }

        public IActionResult OnGet(int rok)
        {
            var visits = _context.Visit.Where(v => v.VisitDate.Date >= DataOd.Date && v.VisitDate.Date <= DataDo.Date).ToList();
            qua = 0;
            mostPopularDoctorCount = 0;

            if (visits.Count > 0)
            {
                var most = visits.GroupBy(i => i.IdDoctor).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                var count = visits.FindAll(v => v.IdDoctor == most).ToList();
                mostPopularDoctorCount = count.Count;
                var doctor = _context.ApplicationUser.FirstOrDefault(v => v.Id == most);
                mostPopularDoctor = doctor.Name + " " + doctor.UserSurname;
            }
            foreach (var visit in visits)
            {
                sum += visit.Price;
                qua++;
            }

            return null;
        }
    }
}
