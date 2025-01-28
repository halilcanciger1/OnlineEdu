using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrate
{
    public class GenericManager<T>(IRepository<T> repository) : IGenericService<T> where T : class
    {
        public int TCount()
        {
            throw new NotImplementedException();
        }

        public void TCreate(T entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public int TFilteredCount(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T TGetByFilter(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> TGetFilteredList(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<T> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
