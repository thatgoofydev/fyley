using System;
using System.Net.Http;
using Fyley.Components.Financial.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Fyley.BFF.Desktop.IntegrationTests
{
    public class IntegrationTestFixture : IDisposable
    {
        private readonly WebApplicationFactory<Startup> _appFactory;

        public IServiceProvider Services => _appFactory.Services;
        
        public IntegrationTestFixture()
        {
            _appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseEnvironment("Test");
                });

            SetupDatabase();
        }

        private void SetupDatabase()
        {
            var financialContext = Services.GetService<FinancialContext>();
            financialContext.Database.EnsureDeleted();
            financialContext.Database.EnsureCreated();
        }

        public HttpClient GetClient()
        {
            return _appFactory.CreateClient();
        }
        
        
        public void Dispose()
        {
            _appFactory.Dispose();
        }
    }
}