using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrate
{
    public class BlogCategoryManager : GenericManager<BlogCategory>, IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public BlogCategoryManager(IRepository<BlogCategory> repository, IBlogCategoryRepository blogCategoryRepository) : base(repository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }


        List<BlogCategory> IBlogCategoryService.TGetBlogCategoriesWithBlog()
        {
            return _blogCategoryRepository.GetBlogCategoriesWithBlog();
        }
    }
}
