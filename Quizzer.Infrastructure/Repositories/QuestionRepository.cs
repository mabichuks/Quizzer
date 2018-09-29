using Quizzer.Domain.Entities;
using Quizzer.Domain.Repository_Interfaces;
using Quizzer.Infrastructure.Data_Access;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Infrastructure.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly QuizzerDbContext _ctxt;
        public QuestionRepository(QuizzerDbContext ctxt): base(ctxt)
        {
            _ctxt = ctxt;
        }

        public IEnumerable<Question> QuestionsandOptions()
        {
         return   _dbContext.Questions.Include(c => c.Options).ToList();
        }

    }
}
