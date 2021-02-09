using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCrecer.Application.Interfaces.UnitOfWork;
using TestCrecer.Infrastructure.Data;
using TestCrecer.Infrastructure.Repositories.UnitOfWork;

namespace TestCrecer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<TestCrecerContext>(options =>
                options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                new MariaDbServerVersion(new System.Version(8, 0, 21)),
                x => x.MigrationsAssembly("TestCrecer.Infrastructure")
                )
            );

            return services;
        }

        public static IServiceCollection AddUoW (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkContainer>();
            return services;
        }
    }
}