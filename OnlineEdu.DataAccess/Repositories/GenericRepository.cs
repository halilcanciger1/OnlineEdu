using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Repositories
{
    public class GenericRepository<T>(IRepository<T> repository) : IRepository<T> where T : class
    {

        public int Count()
        {
            return repository.Count();
        }

        public void Create(T entity)
        {
            repository.Create(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return repository.FilteredCount(predicate);
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return repository.GetByFilter(predicate);
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return repository.GetFilteredList(predicate);
        }

        public List<T> GetList()
        {
            return repository.GetList();
        }

        public void Update(T entity)
        {
            repository.Update(entity);
        }
    }
}
