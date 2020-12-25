using Fyley.Services.Account.Bootstrapper.Grpc.Interceptors;
using Fyley.Services.Account.Bootstrapper.Grpc.Services;
using Fyley.Services.Account.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fyley.Services.Account.Bootstrapper.Grpc
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAccountService();
            services.AddAccountInfrastructure(_configuration);
            
            services.AddGrpc(options =>
            {
                options.Interceptors.Add<RequestLoggerInterceptor>();
                options.Interceptors.Add<ErrorInterceptor>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<AccountGrpcService>();
                endpoints.MapGet("/", async context => await context.Response.WriteAsync("GRPC"));
            });
        }
    }
}