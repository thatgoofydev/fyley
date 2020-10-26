using DDDCore.Infrastructure.CorrelationId;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.Core.Asp.Middleware.CorrelationId
{
    public static class CorrelationIdExtensions
    {
        public static IApplicationBuilder UseCorrelationIds(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationIdMiddleware>();
        }

        public static IServiceCollection AddCorrelationIds(this IServiceCollection services)
        {
            services.AddScoped<ICorrelationContextAccessor, CorrelationContextAccessor>();
            services.AddTransient<ICorrelationContextFactory, CorrelationContextFactory>();
            return services;
        }
    }
}