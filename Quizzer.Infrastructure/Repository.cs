using Quizzer.Domain.Repository_Interfaces;
using Quizzer.Infrastructure.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quizzer.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly QuizzerDbContext _dbContext;

        public Repository(QuizzerDbContext _ctxt)
        {
            _dbContext = _ctxt;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            Save();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            Save();
        }


        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public T Get(int Id)
        {
           return _dbContext.Set<T>().Find(Id);
        }

        public IEnumerable<T> GetAll()
        {
           return _dbContext.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            Save();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
