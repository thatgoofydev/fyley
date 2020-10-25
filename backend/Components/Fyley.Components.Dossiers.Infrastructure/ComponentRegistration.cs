using Fyley.Components.Dossiers.Application;
using Fyley.Components.Dossiers.Application.DataAccess;
using Fyley.Components.Dossiers.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.Components.Dossiers.Infrastructure
{
    public static class ComponentRegistration
    {
        public static void RegisterDossiers(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Services
            services.AddScoped<DossiersService>();
            services.AddScoped<DossiersQueryService>();

            // Database
            services.AddDbContext<DossiersContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Dossiers")));
            services.AddScoped<IDossiersUnitOfWork>(sp => sp.GetService<DossiersContext>());
            services.AddScoped<IDossiersRepository, DossiersRepository>();
            services.AddScoped<IDossiersQueries, DossiersQueries>();
        }
    }
}