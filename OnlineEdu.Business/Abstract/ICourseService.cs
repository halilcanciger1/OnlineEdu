using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseService : IRepository<Course>
    {
        List<Course> GetCoursesByTeacherId(int id);
        List<Course> TGetAllCoursesWithCategories();
        void TShownOnHome(int id);
        void TDontShownOnHome(int id);
        List<Course> TGetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null);
    }
}
