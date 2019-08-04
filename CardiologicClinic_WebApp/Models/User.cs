using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace CardiologicClinic_WebApp.Models
{
    public class User : IdentityUser
    {
        public  User()
        {

        }
        public List<User> GetUsersList(ClaimsPrincipal user)
        {
            var studentList = new List<User>
            {
                            new User() { Id = "test", UserName = "John TEST" }

            };
            return studentList;

        }
        public string UserRole { get; set; }
    }
}
