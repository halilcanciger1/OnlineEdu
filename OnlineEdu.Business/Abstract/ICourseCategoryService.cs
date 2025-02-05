using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseCategoryService : IRepository<CourseCategory>
    {
        void TShownOnHome(int id);
        void TDontShownOnHome(int id);
    }
}
