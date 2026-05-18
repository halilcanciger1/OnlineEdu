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
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogManager(IRepository<Blog> repository, IBlogRepository blogRepository) : base(repository)
        {
            _blogRepository = blogRepository;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Create(Blog entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int FilteredCount(Expression<Func<Blog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _blogRepository.GetBlogsWithCategories();
        }

        public List<Blog> GetBlogsWithCategoriesByWriter(int id)
        {
            return _blogRepository.GetBlogsWithCategoriesByWriter(id);
        }

        public Blog GetByFilter(Expression<Func<Blog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetFilteredList(Expression<Func<Blog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Blog> TGet4BlogsWithCategories()
        {
            return _blogRepository.Get4BlogsWithCategories();
        }

        public List<Blog> TGetBlogsByCategoryId(int id)
        {
            return _blogRepository.GetBlogsByCategoryId(id);
        }

        public Blog TGetBlogWithCategory(int id)
        {
            return _blogRepository.GetBlogWithCategory(id);
        }

        public void Update(Blog entity)
        {
            throw new NotImplementedException();
        }
    }
}
