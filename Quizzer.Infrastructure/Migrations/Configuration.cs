namespace Quizzer.Infrastructure.Migrations
{
    using Quizzer.Domain.Entities;
    using Quizzer.Infrastructure.Identity;
    using Quizzer.Infrastructure.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Quizzer.Infrastructure.Data_Access.QuizzerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Quizzer.Infrastructure.Data_Access.QuizzerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var questions = DummyData.Questions();
            var options = DummyData.Options();
            context.Set<Question>().AddRange(questions);
            context.Set<Option>().AddRange(options);
            FirstUserFactory.CreateFirstUser();


        }
    }
}
