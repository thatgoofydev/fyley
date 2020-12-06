using System;
using System.Threading.Tasks;
using FluentAssertions;
using Fyley.BFF.Desktop.Components.Financial.Accounts;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.List;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;
using NSubstitute;
using Xunit;

namespace Fyley.BFF.Desktop.Tests.Components.Financial.Accounts
{
    public class AccountViewModelFactoryTests
    {
        private readonly IAccountServiceClient _serviceClient;
        private readonly IAccountViewModelFactory _viewModelFactory;
        
        public AccountViewModelFactoryTests()
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

            [Fact]
            public async Task ReturnNotNull()
            {
                // Arrange
                SetupServiceClient();
                
                // Act
                var result = await _viewModelFactory.List();

                // Assert
                result.Should().NotBeNull();

                result.Accounts.Should().ContainSingle(single =>
                    single.AccountId.Equals(Id)
                    && single.Name.Equals(Name)
                    && single.Description.Equals(Description)
                    && single.AccountNumber.Equals(AccountNumber)
                    && single.AccountNumberType.Equals((ListResponse.AccountNumberType)AccountNumberType)
                );

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