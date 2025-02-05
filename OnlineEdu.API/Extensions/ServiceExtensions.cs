using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Concrate;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Concrate;
using OnlineEdu.DataAccess.Repositories;

namespace OnlineEdu.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseCategoryService, CourseCategoryManager>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseManager>();
        }
    }

    
}
