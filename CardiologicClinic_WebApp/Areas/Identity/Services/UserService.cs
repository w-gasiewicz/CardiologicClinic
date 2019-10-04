using AutoMapper;
using CardiologicClinic_WebApp.Data;
using CardiologicClinic_WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace CardiologicClinic_WebApp.Areas.Identity.Services
{
    public class UserService
    {
        public static List<SelectListItem> SortedRoles;

        private string _connectionString;
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        private readonly ApplicationDbContext _context;
        private static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IdentityUser, ApplicationUser>();
        });
        private static MapperConfiguration config2 = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, ApplicationUser>();
        });
        private IMapper _mapper = config.CreateMapper();
        private IMapper _mapper2 = config.CreateMapper();

        public UserService()
        {

        }
        public UserService(ApplicationDbContext context)
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

        public void AddEvent()
        {

        }

        public async System.Threading.Tasks.Task<List<ApplicationUser>> GetListOfUsersAsync()
        {
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var users = await _context.Users.ToListAsync();
                var toReturn = _mapper.Map<List<IdentityUser>, List<ApplicationUser>>(users);
                return toReturn;
            }
        }
        public async System.Threading.Tasks.Task<List<ApplicationUser>> GetListOfDoctorsAsync(UserManager<ApplicationUser> _um)
        {
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var users = await _context.ApplicationUser.ToListAsync();
                users.RemoveAll(x => !_um.IsInRoleAsync(x, "Doctor").Result);
                return users;
            }
        }
        public async System.Threading.Tasks.Task<List<string>> AssignRolesAsync(UserManager<ApplicationUser> _um)
        {
            List<string> roles = new List<string>();
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var users = await _context.Users.ToListAsync();
                foreach (var user in users)
                {
                    var role = await _um.GetRolesAsync((ApplicationUser)user);
                    var array = new List<string>(role).ToArray();
                    roles.Add(array[0]);
                }
            }
            return roles;
        }
        public void SortRoles(UserManager<ApplicationUser> _um, string id)
        {
            SortedRoles = new List<SelectListItem>();
            List<string> roles = new List<string> { "Admin", "User", "Doctor", "Recepcion" };

            var user = _um.FindByIdAsync(id).Result;

            if (_um.IsInRoleAsync(user, "User").Result)
            {
                roles.Remove("User");
                roles.Insert(0, "User");
            }
            else if (_um.IsInRoleAsync(user, "Doctor").Result)
            {
                roles.Remove("Doctor");
                roles.Insert(0, "Doctor");
            }
            else if (_um.IsInRoleAsync(user, "Recepcion").Result)
            {
                roles.Remove("Recepcion");
                roles.Insert(0, "Recepcion");
            }

            foreach (var role in roles)
            {
                SortedRoles.Add(new SelectListItem { Text = role });
            }
        }
    }
}
