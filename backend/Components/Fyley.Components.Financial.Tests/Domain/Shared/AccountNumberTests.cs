using System;
using Fyley.Components.Financial.Domain.Shared;
using Fyley.Components.Financial.Domain.Shared.Errors;
using NUnit.Framework;

namespace Fyley.Components.Financial.Tests.Domain.Shared
{
    // ReSharper disable ObjectCreationAsStatement
    [TestFixture]
    public class AccountNumberTests
    {
        public class ConstructorShould : AccountNumberTests
        {
            [Test]
            public void ThrowArgumentNullException_WhenTypeIsNull()
            {
                // Assert + Act
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new AccountNumber(null, "value"));
                
                Assert.That(exception.ParamName, Is.EqualTo("type"));
            }
            
            [Test]
            public void ThrowArgumentNullException_WhenValueIsNull()
            {
                // Assert + Act
                var exception = Assert.Throws<ArgumentNullException>(() =>
                    new AccountNumber(AccountNumberType.Iban, null));
                
                Assert.That(exception.ParamName, Is.EqualTo("value"));
            }

            [Test]
            public void ThrowAccountNumberInvalid_WhenValueInvalid()
            {
                // Assert + Act
                var exception = Assert.Throws<AccountNumberInvalid>(() =>
                    new AccountNumber(AccountNumberType.Iban, "XX00 0000"));
                
                Assert.That(exception.Message, Is.Not.Null);
            }

            [Test]
            public void NotChangeValue()
            {
                // Act
                var accountNumber = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");
                
                // Assert
                Assert.That(accountNumber.Type, Is.EqualTo(AccountNumberType.Iban));
                Assert.That(accountNumber.Value, Is.EqualTo("BE67173283524787"));
            }
        }
        
        public class EqualShould : AccountNumberTests
        {
            [Test]
            public void Equal()
            {
                var accountNumber1 = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");
                var accountNumber2 = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");

                Assert.That(accountNumber1, Is.EqualTo(accountNumber2));
            }
            
            [Test]
            public void NotEqual_DifferentType()
            {
                var accountNumber1 = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");
                var accountNumber2 = new AccountNumber(AccountNumberType.Other, "BE67173283524787");

                Assert.That(accountNumber1, Is.Not.EqualTo(accountNumber2));
            }
            
            [Test]
            public void NotEqual_DifferentValue()
            {
                var accountNumber1 = new AccountNumber(AccountNumberType.Iban, "BE67173283524787");
                var accountNumber2 = new AccountNumber(AccountNumberType.Iban, "BE00000000000000");

                Assert.That(accountNumber1, Is.Not.EqualTo(accountNumber2));
            }
        }
    }
}