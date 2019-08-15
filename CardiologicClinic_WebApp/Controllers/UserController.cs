using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CardiologicClinic_WebApp.Areas.Identity.Services;
using CardiologicClinic_WebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CardiologicClinic_WebApp.Controllers
{
    public class UserCntroller : Controller
    {
        private string _connectionString;
        private readonly ApplicationDbContext _context;
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
       
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