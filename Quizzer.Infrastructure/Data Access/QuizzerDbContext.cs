using Microsoft.AspNet.Identity.EntityFramework;
using Quizzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Quizzer.Infrastructure.Identity.IdentityModel;

namespace Quizzer.Infrastructure.Data_Access
{
    public class QuizzerDbContext: IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {

        public QuizzerDbContext(): base("QuizzerDbContext")
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}

