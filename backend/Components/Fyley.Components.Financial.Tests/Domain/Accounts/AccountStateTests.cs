using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Accounts.Events;
using Fyley.Components.Financial.Domain.Shared;
using NUnit.Framework;

namespace Fyley.Components.Financial.Tests.Domain.Accounts
{
    [TestFixture]
    public class AccountStateTests
    {
        [Test]
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
            Assert.That(
                state.Name, 
                Is.EqualTo(new AccountName("Savings"))
            );
            Assert.That(
                state.Description,
                Is.EqualTo(new AccountDescription("Description"))
            );
            Assert.That(
                state.AccountNumber,
                Is.EqualTo(new AccountNumber(AccountNumberType.Iban, "BE13131141229739"))
            );
        }
    }
}