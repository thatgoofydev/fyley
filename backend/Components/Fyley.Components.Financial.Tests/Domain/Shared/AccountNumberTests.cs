using System;
using FluentAssertions;
using Fyley.Components.Financial.Domain.Shared;
using Fyley.Components.Financial.Domain.Shared.Errors;
using Xunit;

namespace Fyley.Components.Financial.Tests.Domain.Shared
{
    // ReSharper disable ObjectCreationAsStatement
    public class AccountNumberTests
    {
        public class ConstructorShould : AccountNumberTests
        {
            [Fact]
            public void ThrowArgumentNullException_WhenTypeIsNull()
            {
                // Assert + Act
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new AccountNumber(null, "value"));
                
                exception.ParamName.Should().Be("type");
            }
            
            [Fact]
            public void ThrowArgumentNullException_WhenValueIsNull()
            {
                // Assert + Act
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new AccountNumber(AccountNumberType.Iban, null));

                exception.ParamName.Should().Be("value");
            }

            [Fact]
            public void ThrowAccountNumberInvalid_WhenValueInvalid()
            {
                // Assert + Act
                var exception = Assert.Throws<AccountNumberInvalid>(() =>
                    new AccountNumber(AccountNumberType.Iban, "XX00 0000"));

                exception.Message.Should().NotBeNullOrEmpty();
            }

            [Fact]
            public void NotChangeValue()
            {
                // Act
                var accountNumber = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");
                
                // Assert
                accountNumber.Type.Should().Be(AccountNumberType.Iban);
                accountNumber.Value.Should().Be("BE67173283524787");
            }
        }
        
        public class EqualShould : AccountNumberTests
        {
            [Fact]
            public void Equal()
            {
                var accountNumber1 = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");
                var accountNumber2 = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");

                accountNumber1.Should().Be(accountNumber2);
            }
            
            [Fact]
            public void NotEqual_DifferentType()
            {
                var accountNumber1 = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");
                var accountNumber2 = new AccountNumber(AccountNumberType.Other, "BE67173283524787");
                
                accountNumber1.Should().NotBe(accountNumber2);
            }
            
            [Fact]
            public void NotEqual_DifferentValue()
            {
                var accountNumber1 = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");
                var accountNumber2 = new AccountNumber(AccountNumberType.Iban, "BE00000000000000");

                accountNumber1.Should().NotBe(accountNumber2);
            }
        }
    }
}