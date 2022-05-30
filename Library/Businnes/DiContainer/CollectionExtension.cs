using KUSYSDemo.Business.Concrete;
using KUSYSDemo.Business.Interfaces;
using KUSYSDemo.DataAccess.Interfaces;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Repository;

using Microsoft.Extensions.DependencyInjection;

namespace KUSYSDemo.Business.DiContainer
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Here, we tell the program where to look for calls from the controller over the interface.
        /// </summary>
        /// <param name="services"></param>
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IStudentCourseMapService, StudentCourseMapManager>();

            services.AddScoped<ICourseDal, EfCourseRepository>();
            services.AddScoped<IStudentDal, EfStudentRepository>();
            services.AddScoped<IStudentCourseMapDal, EfStudentCourseMapRepository>();
        }
    }
}
