using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.Submit;
using Fyley.BFF.Desktop.IntegrationTests.Helpers;
using Xunit;

namespace Fyley.BFF.Desktop.IntegrationTests.Financial.Accounts
{
    public class AccountControllerTests : IDisposable
    {
        private IntegrationTestFixture _fixture;
        private HttpClient _http;
        
        public AccountControllerTests()
        {
            _fixture = new IntegrationTestFixture();
            _http = _fixture.GetClient();
        }

        [Fact]
        public async Task SubmitForm_ReturnsRandomId_WhenIdIsNew()
        {
            // Arrange
            var request = new SubmitAccountRequest
            {
                Name = "Saving",
                Description = "For saving some money",
                AccountNumber = "BE34812896199790",
                AccountNumberType = SubmitAccountRequest.AccountNumberTypes.Iban
            };
            
            // Act
            var response = await _http.PostJsonAsync("/bff/desktop/accounts/submit-form/new", request);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            var apiResponse = await response.ReadApiResponseOf<SubmitAccountResponse>();
            apiResponse.Ok.Should().BeTrue();
            apiResponse.Error.Should().BeNull();
            apiResponse.Data.Id.Should().NotBe(Guid.Empty);
        }

        public void Dispose()
        {
            _fixture?.Dispose();
            _http?.Dispose();
        }
    }
}