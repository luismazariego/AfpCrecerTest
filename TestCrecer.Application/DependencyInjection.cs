namespace TestCrecer.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using TestCrecer.Application.Interfaces.UserAccount;
    using TestCrecer.Application.Services.UserAccount;

    public static class DependencyInjection
    {
        public static IServiceCollection AddUserAccountServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }
    }
}