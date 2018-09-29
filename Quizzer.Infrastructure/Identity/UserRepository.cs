using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Quizzer.Infrastructure.Identity.IdentityModel;

namespace Quizzer.Infrastructure.Identity
{
    public class UserRepository: IUserRepository
    {
        private UserManager<AppUser, int> userMgr;
        private RoleManager<AppRole, int> roleMgr;

        public UserRepository()
        {
            userMgr = AuthStartupManager.UserManagerFactory.Invoke();
            roleMgr = AuthStartupManager.RoleManagerFactory.Invoke();
        }

        public IEnumerable<AppRole> GetRoles
        {
            get { return roleMgr.Roles.ToList(); }
        }

        public IEnumerable<AppUser> GetUsers
        {
            get { return userMgr.Users.ToList(); }
        }

        //public async Task<IdentityResult> CreateUser( string email, string password, string role)
        //{
        //    var user = new AppUser
        //    {
        //        UserName = email,
        //        Email = email,
        //    };
        //    IdentityResult identity = await userMgr.CreateAsync(user, password);
        //    if (!roleMgr.RoleExists(role))
        //    {
        //        var irole = new AppRole() { Name = role };
        //        roleMgr.Create(irole);
        //    }
        //    if (!userMgr.IsInRole(user.Id, role))
        //    {
        //        userMgr.AddToRole(user.Id, role);
        //    }
        //    return identity;
        //}

        public async Task<IdentityResult> CreateUser(string email, string password)
        {
            var user = new AppUser
            {
                UserName = email,
                Email = email,
            };
            IdentityResult identity = await userMgr.CreateAsync(user, password);
            return identity;
        }

        public async Task<IdentityResult> CreateUser(string email, string password, string imageUrl)
        {
            var user = new AppUser
            {
                UserName = email,
                Email = email,
                ImageUrl = imageUrl
            };
            IdentityResult identity = await userMgr.CreateAsync(user, password);
            return identity;
        }

        public async Task<IdentityResult> RemoveUser(int userId)
        {
            AppUser user = userMgr.Users.SingleOrDefault(u => u.Id == userId);

            return await userMgr.DeleteAsync(user);
        }

        public async Task<AppUser> SignIn(string username, string password)
        {
            var user = await userMgr.FindAsync(username, password);
            return user;
        }

        public async Task<AppUser> SignIn(UserLoginInfo info)
        {
            var user = await userMgr.FindAsync(info);
            return user;
        }

        public async Task<ClaimsIdentity> FindUserAsync(AppUser user, string authType)
        {
            return await userMgr.CreateIdentityAsync(user, authType);
        }

        public bool IsInRole(AppUser user, string role)
        {
            return userMgr.IsInRole(user.Id, role);
        }

      
    }
}
