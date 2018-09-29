using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Infrastructure.Identity
{
    public class IdentityModel
    {
        public class AppUser : IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>
        {
            public string ImageUrl { get; set; }

        }

        public class AppRole : IdentityRole<int, AppUserRole>
        {

        }
        public class AppUserLogin : IdentityUserLogin<int>
        {
        }

        public class AppUserRole : IdentityUserRole<int>
        {

        }

        public class AppUserClaim : IdentityUserClaim<int>
        {

        }
    }
}
