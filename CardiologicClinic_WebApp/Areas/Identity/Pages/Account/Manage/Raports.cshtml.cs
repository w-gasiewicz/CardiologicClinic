using System;
using System.Collections.Generic;
using System.Globalization;
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
        public int Rok; /*{ get; set; }*/
        public float jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec = 0;
        public float sum;
        public int qua;
        public string mostPopularDoctor;
        public int mostPopularDoctorCount;

        private readonly ApplicationDbContext _context;

        public RaportsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(DateTime DataOd, DateTime DataDo, int Rok)
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
            //OnGet(Rok);
            return null;
        }

        public IActionResult OnGet(int rok)
        {
            if (rok < 1900)
                rok = DateTime.Now.Date.Year;
            Rok = rok;
            DateTime startDate, helper;
            DateTime.TryParseExact(rok.ToString(), "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
            var endDate = new DateTime(startDate.Year, 12, 31);

            DataOd = startDate;
            DataDo = endDate;

            helper = startDate.AddMonths(1);

            var visits = _context.Visit.Where(v => v.VisitDate.Date >= startDate.Date && v.VisitDate.Date <= endDate.Date).ToList();
            int x = 0;
            while (startDate < endDate)
            {
                var actualMonth = visits.FindAll(v => v.VisitDate >= startDate && v.VisitDate <= helper);
                startDate = startDate.AddMonths(1);
                helper = startDate.AddMonths(1);
                if (x == 0)
                {
                    foreach (var visit in actualMonth)
                    {
                        jan += visit.Price;
                    }
                }
                else if (x == 1)
                {
                    foreach (var visit in actualMonth)
                    {
                        feb += visit.Price;
                    }
                }
                else if (x == 2)
                {
                    foreach (var visit in actualMonth)
                    {
                        mar += visit.Price;
                    }
                }
                else if (x == 3)
                {
                    foreach (var visit in actualMonth)
                    {
                        apr += visit.Price;
                    }
                }
                else if (x == 4)
                {
                    foreach (var visit in actualMonth)
                    {
                        may += visit.Price;
                    }
                }
                else if (x == 5)
                {
                    foreach (var visit in actualMonth)
                    {
                        jun += visit.Price;
                    }
                }
                else if (x == 6)
                {
                    foreach (var visit in actualMonth)
                    {
                        jul += visit.Price;
                    }
                }
                else if (x == 7)
                {
                    foreach (var visit in actualMonth)
                    {
                        aug += visit.Price;
                    }
                }
                else if (x == 8)
                {
                    foreach (var visit in actualMonth)
                    {
                        sep += visit.Price;
                    }
                }
                else if (x == 9)
                {
                    foreach (var visit in actualMonth)
                    {
                        oct += visit.Price;
                    }
                }
                else if (x == 10)
                {
                    foreach (var visit in actualMonth)
                    {
                        nov += visit.Price;
                    }
                }
                else if (x == 11)
                {
                    foreach (var visit in actualMonth)
                    {
                        dec += visit.Price;
                    }
                }
                x++;
            }
            OnPostAsync(DataOd, DataDo, rok);
            return null;
        }
    }
}
