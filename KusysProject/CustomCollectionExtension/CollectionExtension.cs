using FluentValidation;
using KUSYSDemo.Business.ValidationRules.FluentValidation;
using KUSYSDemo.Models;

namespace KUSYSDemo.Web.CustomCollectionExtension
{
    public static class CollectionExtension
    {
        public static void AddValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<StudentModel>, StudentValidator>();
        }
    }
}
