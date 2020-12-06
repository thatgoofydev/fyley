using System;
using DDDCore.Domain.Events;
using FluentAssertions;
using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Accounts.Events;
using Fyley.Components.Financial.Domain.Shared;
using Xunit;

namespace Fyley.Components.Financial.Tests.Domain.Accounts
{
    // ReSharper disable ObjectCreationAsStatement
    public class AccountTests
    {
        private static readonly AccountId Id = new AccountId(Guid.NewGuid()); 
        private static readonly AccountName Name = new AccountName("Name1");
        private static readonly AccountDescription Description = new AccountDescription("some description");
        private static readonly AccountNumber AccountNumber = new AccountNumber(AccountNumberType.Iban, "BE52 5577 6699 5309");
            
        public class ConstructorShould : AccountTests
        {
            [Fact]
            public void ThrowArgumentNullException_WhenNameIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(null, Description, AccountNumber));

                exception.ParamName.Should().Be("name");
            }
            
            [Fact]
            public void ThrowArgumentNullException_WhenDescriptionIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(Name, null, AccountNumber));
                
                exception.ParamName.Should().Be("description");
            }
            
            [Fact]
            public void ThrowArgumentNullException_WhenAccountNumberIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(Name, Description, null));
                
                exception.ParamName.Should().Be("accountNumber");
            }

            [Fact]
            public void EmitEvent()
            {
                // Arrange
                var account = new Account(Name, Description, AccountNumber);

                // Act
                var events = account.FlushUncommitedEvents();
                
                // Assert
                events.Should().OnlyContain(@event =>
                    ((AccountDefined) @event.AggregateEvent).Name == Name
                    && ((AccountDefined) @event.AggregateEvent).AccountNumber == AccountNumber
                );
                account.Name.Should().Be(Name);
                account.Description.Should().Be(Description);
                account.AccountNumber.Should().Be(AccountNumber);
            }
        }

        public class Construct2Should : AccountTests
        {
            [Fact]
            public void ThrowArgumentNullException_WhenIdIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(null, new AccountState(), 10));

                exception.ParamName.Should().Be("id");
            }
            
            [Fact]
            public void ThrowArgumentNullException_WhenStateIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new Account(Id, null, 10));
                exception.ParamName.Should().Be("state");
            }
            
            [Fact]
            public void ThrowArgumentException_WhenVersionIsLowerThanNegative1()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentException>(() =>
                    new Account(Id, new AccountState(), -2));
                exception.ParamName.Should().Be("version");
            }
            
            [Fact]
            public void Success()
            {
                // Act + Assert
                new Account(Id, new AccountState(), 0);
            }
        }
    }
}