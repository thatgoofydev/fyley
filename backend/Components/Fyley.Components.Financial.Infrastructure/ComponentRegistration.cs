using Fyley.Components.Financial.Application;
using Fyley.Components.Financial.Application.Transactions;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Infrastructure.DataAccess;
using Fyley.Components.Financial.Infrastructure.DataAccess.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.Components.Financial.Infrastructure
{
    public static class ComponentRegistration
    {
        public static void AddFinancialServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Services
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionQueryService, TransactionQueryService>();

            // DataAccess
            services.AddDbContext<FinancialContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Financial")));
            services.AddScoped<IFinancialUnitOfWork>(sp => sp.GetService<FinancialContext>());
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionQueries, TransactionQueries>();
        }
    }
}