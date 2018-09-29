using Quizzer.Domain.Entities;
using Quizzer.Domain.Repository_Interfaces;
using Quizzer.Infrastructure.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Infrastructure.Repositories
{
    public class OptionRepository: Repository<Option>, IOptionRepository
    {
        public OptionRepository(QuizzerDbContext ctxt): base(ctxt)
        {

        }
    }
}
