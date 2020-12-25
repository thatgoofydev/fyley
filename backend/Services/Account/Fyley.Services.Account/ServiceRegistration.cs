using Fyley.Services.Account.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.Services.Account
{
    public static class ServiceRegistration
    {
        public static void AddAccountService(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountQueryService, AccountQueryService>();
        }
    }
}