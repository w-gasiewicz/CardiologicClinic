using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CardiologicClinic_WebApp.Models;

namespace CardiologicClinic_WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
     {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
         {
         }
        public DbSet<User> User { get; set; }
        public DbSet<Visit> Visit { get; set; }
    }
   
}
