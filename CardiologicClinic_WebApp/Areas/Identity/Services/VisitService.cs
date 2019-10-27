using CardiologicClinic_WebApp.Data;
using CardiologicClinic_WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CardiologicClinic_WebApp.Areas.Identity.Services
{
    public class VisitService
    {
        private string _connectionString;
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
        private readonly ApplicationDbContext _context;

        public static List<SelectListItem> Patients { get; set; }
        public static List<SelectListItem> Doctors { get; set; }
        public static List<SelectListItem> Visits { get; set; }

        public void SortUsersToEditVisit(UserManager<ApplicationUser> _um, string id)
        {

        }

        public async System.Threading.Tasks.Task GetUsers(UserManager<ApplicationUser> _um)
        {
            Doctors = new List<SelectListItem>();
            Patients = new List<SelectListItem>();

            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                Patients = _context.ApplicationUser.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text = a.Name + " " + a.UserSurname
                                          }).ToList();

                Patients.Insert(0, new SelectListItem
                {
                    Value = null,
                    Text = null
                });//add null value to list

                var doctors = await _context.ApplicationUser.ToListAsync();
                doctors.RemoveAll(x => !_um.IsInRoleAsync(x, "Doctor").Result);

                foreach (var doctor in doctors)
                {
                    Doctors.Add(new SelectListItem
                    {
                        Value = doctor.Id.ToString(),
                        Text = doctor.Name + " " + doctor.UserSurname
                    });
                }
            }
        }
        public async System.Threading.Tasks.Task GetVisits(UserManager<ApplicationUser> _um, string doctorId)
        {
            Visits = new List<SelectListItem>();

            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                Visits = _context.Visit.Where(a=> a.IdDoctor == doctorId && a.IdPatient == null).Select(a =>
                          new SelectListItem
                          {
                              Value = a.Id.ToString(),
                              Text = a.VisitDate.ToShortDateString() + " " + a.VisitDate.ToShortTimeString()
                          }).ToList();
            }
        }
        public string GetSpecificUser(string id)
        {
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                if (id == "")
                    return "";
                var User = _context.ApplicationUser.FirstOrDefault(u => u.Id == id);
                return User.Name + " " + User.UserSurname;
            }
        }
        public VisitService()
        {

        }
        public VisitService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration Configuration = builder.Build();
            return Configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}
