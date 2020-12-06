using System;
using FluentAssertions;
using Fyley.Components.Financial.Domain.Shared;
using Xunit;

namespace Fyley.Components.Financial.Tests.Domain.Shared
{
    public class OtherAccountNumberTypeTests
    {
        public class ConstructorShould : OtherAccountNumberTypeTests
        {
            [Fact]
            public void SetCorrectValues()
            {
                // Arrange + Act
                var accountType = AccountNumberType.Other;
                
                // Assert
                accountType.Value.Should().Be(1);
                accountType.Name.Should().Be("Other");
            }
        }

        public class IsValidShould : OtherAccountNumberTypeTests
        {
            [Fact]
            public void ReturnSuccess_WhenValueIsNull()
            {
                // Arrange
                var accountType = AccountNumberType.Other;

                // Act
                var result = accountType.IsValid(null);
                
                // Assert
                result.IsValid.Should().BeTrue();
            }
            
            [Fact]
            public void ReturnSuccess_WhenValueIsRandomString()
            {
                // Arrange
                var accountType = AccountNumberType.Other;
                var value = Guid.NewGuid().ToString();

                // Act
                var result = accountType.IsValid(value);
                
                // Assert
                result.IsValid.Should().BeTrue();
            }
        }

        public class FormatShould : OtherAccountNumberTypeTests
        {
            [Theory]
            [InlineData("test1", "test1")]
            [InlineData("test2", "test2")]
            [InlineData("test3", "test3")]
            public void ReturnInputValue(string inputValue, string expectedReturnValue)
            {
                // Arrange
                var accountType = AccountNumberType.Other;
                
                // Act
                var result = accountType.Format(inputValue);
                
                // Assert
                result.Should().Be(expectedReturnValue);
            }
        }
    }
}