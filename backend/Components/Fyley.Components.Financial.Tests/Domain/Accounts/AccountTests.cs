using System;
using DDDCore.Domain.Events;
using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Accounts.Events;
using Fyley.Components.Financial.Domain.Shared;
using NUnit.Framework;

namespace Fyley.Components.Financial.Tests.Domain.Accounts
{
    // ReSharper disable ObjectCreationAsStatement
    [TestFixture]
    public class AccountTests
    {
        private static readonly AccountId Id = new AccountId(Guid.NewGuid()); 
        private static readonly AccountName Name = new AccountName("Name1");
        private static readonly AccountDescription Description = new AccountDescription("some description");
        private static readonly AccountNumber AccountNumber = new AccountNumber(AccountNumberType.Iban, "BE52 5577 6699 5309");
            
        public class ConstructorShould : AccountTests
        {
            [Test]
            public void ThrowArgumentNullException_WhenNameIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(null, Description, AccountNumber));
                
                Assert.That(exception.ParamName, Is.EqualTo("name"));
            }
            
            [Test]
            public void ThrowArgumentNullException_WhenDescriptionIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(Name, null, AccountNumber));
                
                Assert.That(exception.ParamName, Is.EqualTo("description"));
            }
            
            [Test]
            public void ThrowArgumentNullException_WhenAccountNumberIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(Name, Description, null));
                
                Assert.That(exception.ParamName, Is.EqualTo("accountNumber"));
            }

            [Test]
            public void EmitEvent()
            {
                // Arrange
                var account = new Account(Name, Description, AccountNumber);

                // Act
                var events = account.FlushUncommitedEvents();
                
                // Assert
                Assert.That(events, Has.Exactly(1).Matches<DomainEvent>(@event =>
                {
                    var e = (AccountDefined) @event.AggregateEvent;
                    return e.Name == Name
                           && e.AccountNumber == AccountNumber;
                }));
                Assert.That(account.Name, Is.EqualTo(Name));
                Assert.That(account.Description, Is.EqualTo(Description));
                Assert.That(account.AccountNumber, Is.EqualTo(AccountNumber));
            }
        }

        public class Construct2Should : AccountTests
        {
            [Test]
            public void ThrowArgumentNullException_WhenIdIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(null, new AccountState(), 10));
                
                Assert.That(exception.ParamName, Is.EqualTo("id"));
            }
            
            [Test]
            public void ThrowArgumentNullException_WhenStateIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(Id, null, 10));
                
                Assert.That(exception.ParamName, Is.EqualTo("state"));
            }
            
            [Test]
            public void ThrowArgumentException_WhenVersionIsLowerThanNegative1()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentException>(() =>
                    new Account(Id, new AccountState(), -2));
                
                Assert.That(exception.ParamName, Is.EqualTo("version"));
            }
            
            [Test]
            public void Success()
            {
                // Act + Assert
                Assert.DoesNotThrow(() => new Account(Id, new AccountState(), 0));
            }
        }
    }
}