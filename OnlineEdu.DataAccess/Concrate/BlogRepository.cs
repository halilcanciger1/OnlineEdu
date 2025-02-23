﻿using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Concrate
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly OnlineEduContext _context;

        public BlogRepository(OnlineEduContext context) : base(context)
        {
            _context = context;
        }

        public List<Blog> Get4BlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.BlogCategory).OrderByDescending(x => x.BlogId).Take(4).ToList();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.BlogCategory).ToList();
        }

        public List<Blog> GetBlogsWithCategoriesByWriter(int id)
        {
            return _context.Blogs.Include(x => x.BlogCategory).Where(x => x.WriterId == id).ToList();
        }
    }
}
