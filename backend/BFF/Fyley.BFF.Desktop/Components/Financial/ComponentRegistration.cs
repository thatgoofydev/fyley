using Fyley.BFF.Desktop.Components.Financial.Transactions.Adapters;
using Fyley.BFF.Desktop.Components.Financial.Transactions.ViewModelFactories;
using Fyley.Components.Financial.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.BFF.Desktop.Components.Financial
{
    public static class ComponentRegistration
    {
        public static void AddFinancial(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFinancialServices(configuration);

            services.AddScoped<TransactionServiceAdapter>();

            services.AddScoped<TransactionViewModelFactory>();
        }
    }
}