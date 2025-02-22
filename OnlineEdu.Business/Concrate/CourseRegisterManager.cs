using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrate
{
    public class CourseRegisterManager : GenericManager<CourseRegister>, ICourseRegisterService
    {
        private readonly ICourseRegisterRepository _courseRegisterRepository;
        public CourseRegisterManager(IRepository<CourseRegister> _repository, ICourseRegisterRepository courseRegisterRepository) : base(_repository)
        {
            _courseRegisterRepository = courseRegisterRepository;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Create(CourseRegister entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int FilteredCount(Expression<Func<CourseRegister, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CourseRegister GetByFilter(Expression<Func<CourseRegister, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CourseRegister GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseRegister> GetFilteredList(Expression<Func<CourseRegister, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<CourseRegister> GetList()
        {
            throw new NotImplementedException();
        }

        public List<CourseRegister> TGetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> filter)
        {
            return _courseRegisterRepository.GetAllWithCourseAndCategory(filter);
        }

        public List<CourseRegister> TGetAllWithCourseAndCategory()
        {
            throw new NotImplementedException();
        }

        public void Update(CourseRegister entity)
        {
            throw new NotImplementedException();
        }
    }
}
