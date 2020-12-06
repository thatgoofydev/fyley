using System;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.Submit;
using Fyley.Components.Financial.Contracts.Accounts.Commands.DefineAccount;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;
using Fyley.Components.Financial.Infrastructure.Adapters.Accounts;
using NSubstitute;
using NUnit.Framework;

namespace Fyley.BFF.Desktop.Tests.Components.Financial.Accounts
{
    [TestFixture]
    public class AccountServiceClientTests
    {
        private IAccountServiceAdapter _serviceAdapter;
        private AccountServiceClient _serviceClient;

        [SetUp]
        public void SetUp()
        {
            _serviceAdapter = Substitute.For<IAccountServiceAdapter>();
            _serviceClient = new AccountServiceClient(_serviceAdapter);
        }

        [Test]
        public async Task DefineAccountReturnsId_WithIdNew()
        {
            // Arrange
            const string name = "Savings";
            const string description = "Just saving some money";
            const string accountNumber = "BE18456141662665";
            const int accountNumberType = 2;
                
            var request = new SubmitAccountRequest
            {
                Name = name,
                Description = description,
                AccountNumber = accountNumber,
                AccountNumberType = (SubmitAccountRequest.AccountNumberTypes) accountNumberType
            };

            _serviceAdapter
                .DefineAccount(Arg.Is<DefineAccountRequest>(req => 
                    req.Name.Equals(name)
                    && req.Description.Equals(description)
                    && req.AccountNumber.Equals(accountNumber)
                    && req.AccountNumberType.Equals(accountNumberType)))
                .Returns(new DefineAccountResponse
                {
                    Id = Guid.Parse("74BBD441-BE7F-4B34-ABDF-2CF0DB11094E")
                });
                
            // Act
            var result = await _serviceClient.DefineAccount(request);

            // Assert
            Assert.That(result.Id, Is.Not.Null);

            await _serviceAdapter
                .Received(1)
                .DefineAccount(Arg.Is<DefineAccountRequest>(req =>
                    req.Name.Equals(name)
                    && req.Description.Equals(description)
                    && req.AccountNumber.Equals(accountNumber)
                    && req.AccountNumberType.Equals(accountNumberType)));
        }

        [Test]
        public async Task ListAccountsReturnsAccounts()
        {
            // Arrange
            var id = Guid.NewGuid();
            const string name = "Savings";
            const string description = "Just saving some money";
            const string accountNumber = "BE18456141662665";
            const int accountNumberType = 2;
            
            _serviceAdapter
                .ListAccounts(Arg.Any<ListAccountsRequest>())
                .Returns(new ListAccountsResponse(new[]
                {
                    new ListAccountsResponse.AccountDto
                    {
                        AccountId = id,
                        Name = name,
                        Description = description,
                        AccountNumber = accountNumber,
                        AccountNumberType = accountNumberType
                    }
                }));
            
            // Act
            var result = await _serviceClient.ListAccounts();

            // Assert
            Assert.That(result, Has.Length.EqualTo(1));
            var single = result[0];
            Assert.That(single.AccountId, Is.EqualTo(id));
            Assert.That(single.Name, Is.EqualTo(name));
            Assert.That(single.Description, Is.EqualTo(description));
            Assert.That(single.AccountNumber, Is.EqualTo(accountNumber));
            Assert.That(single.AccountNumberType, Is.EqualTo(accountNumberType));
        }
    }
}