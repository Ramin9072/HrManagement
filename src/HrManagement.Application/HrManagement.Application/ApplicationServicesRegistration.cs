
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HrManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(MappingProfile)); // فقط مختص به همین پروفایل است
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // هر آنچه که با اتومتر باشد برداشته میشود
        }
    }
}
