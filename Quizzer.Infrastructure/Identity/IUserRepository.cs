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
    public interface IUserRepository
    {
        IEnumerable<AppRole> GetRoles { get; }
        IEnumerable<AppUser> GetUsers { get; }

        Task<IdentityResult> CreateUser(string email, string password);

        Task<IdentityResult> CreateUser(string email, string password, string imageUrl);

        Task<IdentityResult> RemoveUser(int userId);
        Task<AppUser> SignIn(string username, string password);

        Task<AppUser> SignIn(UserLoginInfo info);
        Task<ClaimsIdentity> FindUserAsync(AppUser user, string authType);
        bool IsInRole(AppUser user, string role);
    }
}
