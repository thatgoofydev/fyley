using System;
using DDDCore.Domain.Events;
using Fyley.Components.Accounts.Domain;
using Fyley.Components.Accounts.Domain.Events;
using NUnit.Framework;

namespace Fyley.Components.Accounts.Tests.Domain
{
    [TestFixture]
    public class AccountTests
    {
        public class ConstructorOneShould : AccountTests
        {
            [Test]
            public void ThrowArgumentNullException_WhenNameNull()
            {
                // Arrange
                AccountName name = null;
                var description = new AccountDescription("General savings account");
                var accountNumber = new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616");
                var money = new Money(20.00m);
                
                // Act + Assert
                Assert.Throws<ArgumentNullException>(() =>
                    new Account(name, description, accountNumber, money));
            }
            
            [Test]
            public void ThrowArgumentNullException_WhenDescriptionNull()
            {
                // Arrange
                var name = new AccountName("Savings account");
                AccountDescription description = null;
                var accountNumber = new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616");
                var money = new Money(20.00m);
                
                // Act + Assert
                Assert.Throws<ArgumentNullException>(() =>
                    new Account(name, description, accountNumber, money));
            }
            
            [Test]
            public void ThrowArgumentNullException_WhenAccountNumberNull()
            {
                // Arrange
                var name = new AccountName("Savings account");
                var description = new AccountDescription("General savings account");
                AccountNumber accountNumber = null;
                var money = new Money(20.00m);
                
                // Act + Assert
                Assert.Throws<ArgumentNullException>(() =>
                    new Account(name, description, accountNumber, money));
            }
            
            [Test]
            public void ThrowArgumentNullException_WhenBalanceNull()
            {
                // Arrange
                var name = new AccountName("Savings account");
                var description = new AccountDescription("General savings account");
                var accountNumber = new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616");
                Money balance = null;
                
                // Act + Assert
                Assert.Throws<ArgumentNullException>(() =>
                    new Account(name, description, accountNumber, balance));
            }

            [Test]
            public void EmitEvent_AccountDefined()
            {
                // Assert
                var name = new AccountName("Savings account");
                var description = new AccountDescription("General savings account");
                var accountNumber = new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616");
                var balance = new Money(20.00m);
                
                // Act
                var account = new Account(name, description, accountNumber, balance);
                
                // Assert
                var events = account.FlushUncommitedEvents();
                Assert.That(
                    events, 
                    Has.Exactly(1).Matches<DomainEvent>(de => de.AggregateEvent.GetType() == typeof(AccountDefined))
                );
            }
        }

        public class ConstructorTwoShould : AccountTests
        {
            [Test]
            public void PassTheValuesWithoutModification()
            {
                // Arrange
                var id = new AccountId(Guid.Parse("6f633f07-7160-47f0-bd80-253cdeacd71c"));
                var state = new AccountState
                {
                    Name = new AccountName("Savings account"),
                    Description = new AccountDescription("General savings account"),
                    AccountNumber = new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616"),
                    Balance = new Money(20.00m)
                };
                const long version = 1L;
                
                // Act
                var account = new Account(id, state, version);
                
                // Assert
                Assert.That(account.Id, Is.EqualTo(new AccountId(Guid.Parse("6f633f07-7160-47f0-bd80-253cdeacd71c"))));
                Assert.That(account.Version, Is.EqualTo(1L));
                Assert.True(IsSameAccountState(account.State, new AccountState
                {
                    Name = new AccountName("Savings account"),
                    Description = new AccountDescription("General savings account"),
                    AccountNumber = new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616"),
                    Balance = new Money(20.00m)
                }));
            }

            private static bool IsSameAccountState(AccountState first, AccountState other)
            {
                return first.Name.Equals(other.Name)
                       && first.Description.Equals(other.Description)
                       && first.AccountNumber.Equals(other.AccountNumber)
                       && first.Balance.Equals(other.Balance);
            }
        }

        public class PropertiesShould
        {
            [Test]
            public void ReturnValueOfState()
            {
                // Arrange
                var id = new AccountId(Guid.Parse("6f633f07-7160-47f0-bd80-253cdeacd71c"));
                var state = new AccountState
                {
                    Name = new AccountName("Savings account"),
                    Description = new AccountDescription("General savings account"),
                    AccountNumber = new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616"),
                    Balance = new Money(20.00m)
                };
                const long version = 1L;
                var account = new Account(id, state, version);
                
                // Act
                var name = account.Name;
                var description = account.Description;
                var accountNumber = account.AccountNumber;
                var balance = account.Balance;

                // Assert
                Assert.That(name, Is.EqualTo(new AccountName("Savings account")));
                Assert.That(description, Is.EqualTo(new AccountDescription("General savings account")));
                Assert.That(accountNumber, Is.EqualTo(new AccountNumber(AccountNumberType.Iban, "BE72 2337 6747 9616")));
                Assert.That(balance, Is.EqualTo(new Money(20.00m)));
            }
        }
    }
}