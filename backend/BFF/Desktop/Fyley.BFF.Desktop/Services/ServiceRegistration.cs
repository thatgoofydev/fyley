using System;
using Fyley.Services.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.BFF.Desktop.Services
{
    public static class ServiceRegistration
    {
        public static void RegisterGrpcServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterGrpcService<AccountService.AccountServiceClient>(configuration, "Services:Account");
        }

        private static void RegisterGrpcService<TGrpcServiceClient>(
            this IServiceCollection services,
            IConfiguration configuration, 
            string configUrlPath)
            where TGrpcServiceClient : class
        {
            services.AddGrpcClient<TGrpcServiceClient>(options =>
            {
                options.Address = new Uri(configuration.GetValue<string>(configUrlPath));
                options.Interceptors.Add(new LoggerInterceptor());
            });
        }
    }
}