using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using CardiologicClinic_WebApp.Data;
using CardiologicClinic_WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CardiologicClinic_WebApp.Controllers
{
    public class UserController : Controller
    {
        private string _connectionString;//= @"Server=(localdb)\\mssqllocaldb;Database=CardioDB;AttachDBFileName=C:\\Users\\FUJITSU\\CardioDB.mdf;Trusted_Connection=True;MultipleActiveResultSets=true";
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        public ActionResult Index()
        {
            var studentList = new List<User>{

                        };
            // Get the students from the database in the real application

            return View(studentList);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration Configuration = builder.Build();
            return Configuration["ConnectionStrings:DefaultConnection"];
        }
        public string GetUserRole(ClaimsPrincipal user)
        {
            return "Admin";
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var role = _context.Users.FromSql($"SELECT UserRole From AspNetUsers Where UserName = {user.Identity.Name}").FirstOrDefault();
                return role.ToString();
            }
        }
    }
}