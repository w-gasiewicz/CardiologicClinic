using System.IO;
using CardiologicClinic_WebApp.Areas.Identity.Services;
using CardiologicClinic_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CardiologicClinic_WebApp.Controllers
{
    public class UserCntroller : Controller
    {
        private readonly string _connectionString;
        private readonly ApplicationDbContext _context;
        readonly DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
       
        public ActionResult Index()
        {
            UserService us = new UserService(_context);
            var ListOfUsers = us.GetListOfUsersAsync();
            return View(ListOfUsers);
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