using Microsoft.AspNetCore.Identity;

namespace cross_lab5.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
