using System;
using System.Threading.Tasks;
using FluentAssertions;
using Fyley.BFF.Desktop.Components.Financial.Accounts;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.Submit;
using Fyley.Components.Financial.Contracts.Accounts.Commands.DefineAccount;
using Fyley.Components.Financial.Contracts.Accounts.Queries.ListAccounts;
using Fyley.Components.Financial.Infrastructure.Adapters.Accounts;
using NSubstitute;
using Xunit;

namespace Fyley.BFF.Desktop.Tests.Components.Financial.Accounts
{
    public class AccountServiceClientTests
    {
        private readonly IAccountServiceAdapter _serviceAdapter;
        private readonly AccountServiceClient _serviceClient;
        
        public AccountServiceClientTests()
        {
            _serviceAdapter = Substitute.For<IAccountServiceAdapter>();
            _serviceClient = new AccountServiceClient(_serviceAdapter);
        }

        [Fact]
        public async Task DefineAccountReturnsId()
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
            result.Id.Should().NotBeEmpty();

            await _serviceAdapter
                .Received(1)
                .DefineAccount(Arg.Is<DefineAccountRequest>(req =>
                    req.Name.Equals(name)
                    && req.Description.Equals(description)
                    && req.AccountNumber.Equals(accountNumber)
                    && req.AccountNumberType.Equals(accountNumberType)));
        }

        [Fact]
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
            result.Should().ContainSingle(single =>
                single.AccountId.Equals(id)
                && single.Name.Equals(name)
                && single.Description.Equals(description)
                && single.AccountNumber.Equals(accountNumber)
                && single.AccountNumberType.Equals(accountNumberType)
            );
        }
    }
}