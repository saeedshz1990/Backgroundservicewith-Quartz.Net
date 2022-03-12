using System;
using EmailsManagements.Application;
using EmailsManagements.Application.Contracts.EmailsApplication;
using EmailsManagements.infrastructure.EFCore;
using EmailsManagements.infrastructure.EFCore.Repository;
using EmailsManagents.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmailsManagements.Infrastructure.Configuration
{
    public class EmailBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IEmailApplication, EmailApplication>();
            services.AddTransient<IEmailsRepository, EmailsRepository>();


            services.AddDbContext<EmailsContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
