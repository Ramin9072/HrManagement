﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HrManagement.Application.DTOs.Email;
using HrManagement.Application.Contracts.Infrastructure.Abstraction;
using HrManagement.Infrastructure.Email;

namespace HrManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
