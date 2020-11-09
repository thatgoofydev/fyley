using Fyley.Components.Accounts.Application;
using Fyley.Components.Accounts.Application.DataAccess;
using Fyley.Components.Accounts.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.Components.Accounts.Infrastructure
{
    public static class ComponentRegistration
    {
        public static void RegisterAccounts(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Services
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IAccountsQueryService, AccountsQueryService>();
            
            // DataAccess
            services.AddDbContext<AccountsContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Accounts")));
            services.AddScoped<IAccountsUnitOfWork>(sp => sp.GetService<AccountsContext>());
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}