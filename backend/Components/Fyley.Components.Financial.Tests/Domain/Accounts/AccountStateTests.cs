using FluentAssertions;
using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Accounts.Events;
using Fyley.Components.Financial.Domain.Shared;
using Xunit;

namespace Fyley.Components.Financial.Tests.Domain.Accounts
{
    public class AccountStateTests
    {
        [Fact]
        public void Apply_AccountDefined_ShouldUpdateFields()
        {
            // Arrange
            var state = new AccountState();
            var @event = new AccountDefined(
                new AccountName("Savings"),
                new AccountDescription("Description"), 
                new AccountNumber(AccountNumberType.Iban, "BE13131141229739")
            );
            
            // Act
            state.Apply(@event);
            
            // Assert
            state.Name.Should().Be(new AccountName("Savings"));
            state.Description.Should().Be(new AccountDescription("Description"));
            state.AccountNumber.Should().Be(new AccountNumber(AccountNumberType.Iban, "BE13131141229739"));
        }
    }
}