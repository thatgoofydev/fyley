using Fyley.BFF.Desktop.Financial.Accounts.Adapters;
using Fyley.BFF.Desktop.Financial.Accounts.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.BFF.Desktop.Financial.Accounts
{
    public static class AccountsRegistration
    {
        public static void RegisterAccounts(this IServiceCollection services)
        {
            services.AddScoped<AccountListViewModelFactory>();

            services.AddScoped<SubmitDefineAccountFormAdapter>();
            services.AddScoped<ArchiveAccountAdapter>();
        }
    }
}