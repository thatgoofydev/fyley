using System;
using Fyley.Components.Financial.Domain.Shared;
using NUnit.Framework;

namespace Fyley.Components.Financial.Tests.Domain.Shared
{
    [TestFixture]
    public class OtherAccountNumberTypeTests
    {
        public class ConstructorShould : OtherAccountNumberTypeTests
        {
            [Test]
            public void SetCorrectValues()
            {
                // Arrange + Act
                var accountType = AccountNumberType.Other;
                
                // Assert
                Assert.That(accountType.Value, Is.EqualTo(1));
                Assert.That(accountType.Name, Is.EqualTo("Other"));
            }
        }

        public class IsValidShould : OtherAccountNumberTypeTests
        {
            [Test]
            public void ReturnSuccess_WhenValueIsNull()
            {
                // Arrange
                var accountType = AccountNumberType.Other;

                // Act
                var result = accountType.IsValid(null);
                
                // Assert
                Assert.That(result.IsValid, Is.True);
            }
            
            [Test]
            public void ReturnSuccess_WhenValueIsRandomString()
            {
                // Arrange
                var accountType = AccountNumberType.Other;
                var value = Guid.NewGuid().ToString();

                // Act
                var result = accountType.IsValid(value);
                
                // Assert
                Assert.That(result.IsValid, Is.True);
            }
        }

        public class FormatShould : OtherAccountNumberTypeTests
        {
            [TestCase("test1", "test1")]
            [TestCase("test2", "test2")]
            [TestCase("test3", "test3")]
            public void ReturnInputValue(string inputValue, string expectedReturnValue)
            {
                // Arrange
                var accountType = AccountNumberType.Other;
                
                // Act
                var result = accountType.Format(inputValue);
                
                // Assert
                Assert.That(result, Is.EqualTo(expectedReturnValue));
            }
        }
    }
}