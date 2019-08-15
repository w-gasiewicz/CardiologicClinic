using AutoMapper;
using CardiologicClinic_WebApp.Data;
using CardiologicClinic_WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace CardiologicClinic_WebApp.Areas.Identity.Services
{
    public class UserService
    {
        private string _connectionString;
        DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        private readonly ApplicationDbContext _context;
        private static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<IdentityUser, User>();
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

        public async System.Threading.Tasks.Task<List<User>> GetListOfUsersAsync()
        {
            _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var users = await _context.Users.ToListAsync();
                var toReturn = _mapper.Map<List<IdentityUser>, List<User>>(users);
                return toReturn;
            }
        }
        public async System.Threading.Tasks.Task<List<string>> AssignRolesAsync(UserManager<ApplicationUser> _um)
        {
            //var users2 = _mapper2.Map<List<User>, List<IdentityUser>>(users);
            // int i = 0;
            // foreach (var user in users2)
            // {

            //     var role = await _um.GetRolesAsync(user);
            //     var array = new List<string>(role).ToArray();
            //     users[i].UserRole = array[0];
            //     i++;
            // }
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
    }
}
