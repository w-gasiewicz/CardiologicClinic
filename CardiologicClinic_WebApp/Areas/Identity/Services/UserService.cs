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
        private IMapper _mapper = config.CreateMapper();

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
        { _connectionString = GetConnectionString();
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_connectionString);
            using (ApplicationDbContext _context = new ApplicationDbContext(_optionsBuilder.Options))
            {
                var users = await _context.Users.ToListAsync();
                var toReturn = _mapper.Map<List<IdentityUser>, List<User>>(users);
                return toReturn;
            }
        }
    }
}
