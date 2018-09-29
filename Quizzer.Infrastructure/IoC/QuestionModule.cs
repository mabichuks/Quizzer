using Ninject.Modules;
using Quizzer.Domain.Repository_Interfaces;
using Quizzer.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Infrastructure.IoC
{
    public class QuestionModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IQuestionRepository)).To(typeof(QuestionRepository));
        }
    }
}
