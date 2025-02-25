using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogService : IRepository<Blog>
    {
        List<Blog> GetBlogsWithCategories();

        List<Blog> GetBlogsWithCategoriesByWriter(int id);

        List<Blog> TGet4BlogsWithCategories();

        List<Blog> TGetBlogsByCategoryId(int id);

        Blog TGetBlogWithCategory(int id);
    }
}
