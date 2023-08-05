using Autofac;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.Contracts.Persistence.GenericRepository;
using HrManagement.Domain;
using HrManagement.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HrManagement.EfCore
{
    public static class EfCoreServicesRegistration 
    {

        // IOC
        public static IServiceCollection configureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("databaseConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }

        // AutoFac
        //public static void Configure(IServiceCollection services, IConfiguration configuration) {

        //    services.AddDbContext<LeaveManagementDbContext>(options =>
        //    {
        //        options.UseSqlServer(configuration.GetConnectionString("databaseConnection"));
        //    });
        //}

        //protected override void Load(ContainerBuilder builder)
        //{
        //    builder.RegisterAssemblyTypes(typeof(LeaveType).Assembly)
        //        .Where(p => p.Name.EndsWith("GenericRepository")).AsImplementedInterfaces();
        //    base.Load(builder);
        //}
    }
}
