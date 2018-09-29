using Quizzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Infrastructure.Repositories
{
    public class DummyData
    {
        public static IEnumerable<Category> CreateCategories()
        {
            var C = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Math"
                },
                new Category
                {
                    Name = "Science"
                }

            };

            return C;
        }


        public static IEnumerable<Question> Questions()
        {
            var q = new List<Question>
            {
                new Question
                {
                    Id = 1,
                    Category = new Category
                    {
                       Id = 1,
                       Name = "Math"
                    },
                    Text = "Square root of 25",
                },

               new Question
               {
                   Id = 2,
                   Category = new Category
                   {
                       Id = 2,
                       Name = "English"
                   },
                   Text = "What is the opposite of good"
               }
            };

            return q;
        }

        public static IEnumerable<Option> Options()
        {
            var o = new List<Option>
            {
                new Option
                {
                    QuestionId = 1,
                    Text = "3",
                    IsCorrectOption = false
                },
                 new Option
                {
                    QuestionId = 1,
                    Text = "4",
                    IsCorrectOption = false
                },

                  new Option
                {
                    QuestionId = 1,
                    Text = "5",
                    IsCorrectOption = true
                },

                   new Option
                {
                    QuestionId = 2,
                    Text = "worst",
                    IsCorrectOption = false
                },

                    new Option
                {
                    QuestionId = 2,
                    Text = "better",
                    IsCorrectOption = false
                },

                     new Option
                {
                    QuestionId = 2,
                    Text = "bad",
                    IsCorrectOption = true
                },

            };

            return o;
        }
    }
}
