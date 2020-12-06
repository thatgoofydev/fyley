using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.Submit;
using Fyley.BFF.Desktop.IntegrationTests.Helpers;
using NUnit.Framework;

namespace Fyley.BFF.Desktop.IntegrationTests.Financial.Accounts
{
    [TestFixture]
    public class AccountControllerTests : IDisposable
    {
        private IntegrationTestFixture _fixture;
        private HttpClient _http;
        
        [SetUp]
        public void SetUp()
        {
            _fixture = new IntegrationTestFixture();
            _http = _fixture.GetClient();
        }

        [Test]
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
            Assert.That(response.IsSuccessStatusCode);

            var apiResponse = await response.ReadApiResponseOf<SubmitAccountResponse>();
            Assert.That(apiResponse.Ok, Is.True);
            Assert.That(apiResponse.Error, Is.Null);
            Assert.That(apiResponse.Data.Id, Is.Not.Null);
        }

        public void Dispose()
        {
            _fixture?.Dispose();
            _http?.Dispose();
        }
    }
}