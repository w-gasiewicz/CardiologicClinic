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
        public void GetUsers(UserManager<ApplicationUser> _um)
        {
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                Patients = _context.ApplicationUser.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text =a.Name +" "+ a.UserSurname
                                          }).ToList();

                Patients.Add(new SelectListItem
                {
                    Value = null,
                    Text = null
                });//add null value to list
                
                Doctors = _context.ApplicationUser.Select(a => 
                                             new SelectListItem
                                             {
                                                 Value = a.Id.ToString(),
                                                 Text = a.Name + " " + a.UserSurname
                                             }).ToList();

                //Doctors = _context.ApplicationUser.Where(u => u.Role == "Doctor").Select(a =>
                //                             new SelectListItem
                //                             {
                //                                 Value = a.Id.ToString(),
                //                                 Text = a.Name + " " + a.UserSurname
                //                             }).ToList();
            }
        }
        public string GetSpecificUser(string id)
        {
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var User = _context.ApplicationUser.FirstOrDefault(u => u.Id == id);
                return  User.Name + " " + User.UserSurname;
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
