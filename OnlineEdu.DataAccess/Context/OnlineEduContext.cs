﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Context
{
    public class OnlineEduContext: IdentityDbContext<AppUser, AppRole, int>
    {
        public OnlineEduContext(DbContextOptions options): base(options)
        {
            
        }


        public DbSet<About> Abouts { get; set; }

        public DbSet<Banner> Banners { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogCategory> BlogsCategories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<CourseCategory> CourseCategories { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<SocialMedia> SocialMedia { get; set; }

        public DbSet<Message> Message { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }
        public object Courses { get; internal set; }

        public DbSet<TeacherSocial> TeachersSocials { get; set; }

        public DbSet<CourseRegister> CourseRegisters { get; set; }

        public DbSet<CourseVideo> CourseVideos { get; set; }
    }
}
