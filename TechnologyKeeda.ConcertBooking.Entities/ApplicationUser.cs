using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Identity :  authentication credentials (UserName, Password)& Authorization (Access Rights)
//Authentication
//Register IdentityUser class - Id(Guid), UserName, Password, Email, Phone

namespace ConcertBooking.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? Pincode { get; set; }
    }
}
