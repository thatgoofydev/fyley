using Fyley.Components.Accounts.Domain;
using Fyley.Components.Accounts.Domain.Events;
using NUnit.Framework;

namespace Fyley.Components.Accounts.Tests.Domain
{
    [TestFixture]
    public class AccountStateTests
    {

        [Test]
        public void ApplyAccountDefined_ShouldUpdateCorrectField()
        {
            var state = new AccountState();
            var @event = new AccountDefined(
                new AccountName("Savings account"),
                new AccountDescription("General savings account"),
                new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616"),
                new Money(20.00m)
            );
            
            state.Apply(@event);
            
            Assert.That(state.Name, Is.EqualTo(new AccountName("Savings account")));
            Assert.That(state.Description, Is.EqualTo(new AccountDescription("General savings account")));
            Assert.That(state.AccountNumber, Is.EqualTo(new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616")));
            Assert.That(state.Balance, Is.EqualTo(new Money(20.00m)));
        }
        
    }
}