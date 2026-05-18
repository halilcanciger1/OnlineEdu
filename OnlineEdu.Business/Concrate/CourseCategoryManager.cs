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
    public class CourseCategoryManager : GenericManager<CourseCategory>, ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        public CourseCategoryManager(IRepository<CourseCategory> _repository, ICourseCategoryRepository courseCategoryRepository) : base(_repository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }

        public void TDontShownOnHome(int id)
        {
            _courseCategoryRepository.DontShownOnHome(id);
        }

        public void TShownOnHome(int id)
        {
            _courseCategoryRepository.ShownOnHome(id);
        }

        public List<CourseCategory> GetList()
        {
            throw new NotImplementedException();
        }

        public CourseCategory GetByFilter(Expression<Func<CourseCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CourseCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(CourseCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int FilteredCount(Expression<Func<CourseCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<CourseCategory> GetFilteredList(Expression<Func<CourseCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
