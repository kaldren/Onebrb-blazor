using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onebrb.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Every user has messages
        public List<ApplicationUserMessage> ApplicationUserMessages { get; set; }
    }
}
