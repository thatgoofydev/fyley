using System;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.List;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;
using NSubstitute;
using NUnit.Framework;

namespace Fyley.BFF.Desktop.Tests.Components.Financial.Accounts
{
    [TestFixture]
    public class AccountViewModelFactoryTests
    {
        private IAccountServiceClient _serviceClient;
        private IAccountViewModelFactory _viewModelFactory;

        [SetUp]
        public void SetUp()
        {
            _serviceClient = Substitute.For<IAccountServiceClient>();
            _viewModelFactory = new AccountViewModelFactory(_serviceClient);
        }

        public class ListShould : AccountViewModelFactoryTests
        {
            
            private static readonly Guid Id = Guid.NewGuid();
            private const string Name = "Savings";
            private const string Description = "Savings";
            private const string AccountNumber = "Savings";
            private const int AccountNumberType = 2;

            [Test]
            public async Task ReturnNotNull()
            {
                // Arrange
                SetupServiceClient();
                
                // Act
                var result = await _viewModelFactory.List();

                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Accounts, Has.Length.EqualTo(1));
                Assert.That(result.Accounts[0].AccountId, Is.EqualTo(Id));
                Assert.That(result.Accounts[0].Name, Is.EqualTo(Name));
                Assert.That(result.Accounts[0].Description, Is.EqualTo(Description));
                Assert.That(result.Accounts[0].AccountNumber, Is.EqualTo(AccountNumber));
                Assert.That(result.Accounts[0].AccountNumberType, Is.EqualTo((ListResponse.AccountNumberType)AccountNumberType));

                await _serviceClient
                    .Received(1)
                    .ListAccounts();
            }

            private void SetupServiceClient()
            {
                _serviceClient
                    .ListAccounts()
                    .Returns(new[]
                    {
                        new ListAccountsResponse.AccountDto
                        {
                            AccountId = Id,
                            Name = Name,
                            Description = Description,
                            AccountNumber = AccountNumber,
                            AccountNumberType = AccountNumberType
                        }
                    });
            }
        }
    }
}