using DDDCore.Application.DataAccess;
using Fyley.Services.Account.Application;
using Fyley.Services.Account.Application.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.Services.Account.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void AddAccountInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Accounts"));
            });
            
            services.AddScoped<IUnitOfWork>(sp => sp.GetService<AccountDbContext>());
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IQueries, Queries>();
        }
    }
}