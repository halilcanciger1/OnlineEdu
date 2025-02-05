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
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(IRepository<Course> repository, ICourseRepository courseRepository) : base(repository)
        {
            _courseRepository = courseRepository;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Create(Course entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int FilteredCount(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Course GetByFilter(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Course GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetFilteredList(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetList()
        {
            throw new NotImplementedException();
        }

        public void TDontShownOnHome(int id)
        {
            _courseRepository.DontShownOnHome(id);
        }

        public void TShownOnHome(int id)
        {
            _courseRepository.ShownOnHome(id);
        }

        public void Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
