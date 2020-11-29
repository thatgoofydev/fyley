using Fyley.Components.Financial.Application;
using Fyley.Components.Financial.Application.Accounts;
using Fyley.Components.Financial.Application.Accounts.DataAccess;
using Fyley.Components.Financial.Application.Transactions;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Infrastructure.DataAccess;
using Fyley.Components.Financial.Infrastructure.DataAccess.Accounts;
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
            #region Shared

            // DataAccess
            services.AddDbContext<FinancialContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Financial")));
            services.AddScoped<IFinancialUnitOfWork>(sp => sp.GetService<FinancialContext>());

            #endregion Shared

            #region Accounts

            // Application Services
            services.AddScoped<IAccountService, AccountService>();
            
            // DataAccess
            services.AddScoped<IAccountRepository, AccountRepository>();

            #endregion Accounts
            
            #region Transactions

            // Application Services
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionQueryService, TransactionQueryService>();

            // DataAccess
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionQueries, TransactionQueries>();

            #endregion Transactions
        }
    }
}