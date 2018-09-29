using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Quizzer.Infrastructure.Identity.IdentityModel;

namespace Quizzer.Infrastructure.Identity
{
    public class FirstUserFactory
    {

        public static void CreateFirstUser()
        {
            string username = "admin@cyberspace.com";
            string password = "admin";

            var userMgr = AuthStartupManager.UserManagerFactory.Invoke();

            if (userMgr.FindByName(username) != null)
                return;


            var user = new AppUser() { UserName = username, Email = username };
            var result = userMgr.Create(user, password);
        }
    }
}
