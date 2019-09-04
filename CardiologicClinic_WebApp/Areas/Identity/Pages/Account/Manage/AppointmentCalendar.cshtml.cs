using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CardiologicClinic_WebApp.Data;
using CardiologicClinic_WebApp.Models;
using DHTMLX.Scheduler;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CardiologicClinic_WebApp.Areas.Identity.Pages.Account.Manage
{
    public class AppointmentCalendarModel : PageModel
    {
        private string _connectionString;
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        private UserManager<ApplicationUser> _userManager;

        public AppointmentCalendarModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration Configuration = builder.Build();
            return Configuration["ConnectionStrings:DefaultConnection"];
        }
        public async Task<List<Visit>> GetUsersVisitAsync()
        {
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var visits = await _context.Visit.ToListAsync();
                var user = await _userManager.GetUserAsync(User);

                foreach (var item in visits)
                {
                    if (item.IdPatient != user.Id)
                        visits.Remove(item);
                }

                return visits;
            }
        }
        public class SchedulerEvent
        {
            DateTime start_date;
            DateTime end_date;
            String text;

            public SchedulerEvent(DateTime start, DateTime end, String text)
            {
                this.start_date = start;
                this.end_date = end.AddHours(1);//visit take always 1 hour
                this.text = text;
            }
        }
        public List<SchedulerEvent> FillCalendar(List<Visit> visits)
        {
            List<SchedulerEvent> schedulerEvents = new List<SchedulerEvent>();

            foreach(var item in visits)
            {
                SchedulerEvent se = new SchedulerEvent(item.VisitDate, item.VisitDate, item.VisitName);
                schedulerEvents.Add(se);
            }
            return schedulerEvents;
        }
    }
}