﻿using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Concrate
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(OnlineEduContext context) : base(context)
        {
        }

        public void DontShownOnHome(int id)
        {
            var values = _context.Course.Find(id);
            values.IsShown = false;
            _context.SaveChanges();
        }

        public List<Course> GetAllCoursesWithCategories()
        {
            return _context.Course.Include(x => x.CourseCategory).Include(x => x.AppUser).ToList();
        }

        public List<Course> GetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null)
        {
            IQueryable<Course> courses = _context.Course.Include(x => x.CourseCategory).Include(x => x.AppUser).AsQueryable();
            if (filter != null)
            {
                courses = courses.Where(filter);
            }
            return courses.ToList();
        }

        public List<Course> GetCoursesByTeacherId(int id)
        {
            return _context.Course.Include(x => x.CourseCategory).Where(x => x.AppUserId == id).ToList();
        }

        public void ShownOnHome(int id)
        {
            var values = _context.Course.Find(id);
            values.IsShown = true;
            _context.SaveChanges();
        }
    }
}
