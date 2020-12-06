using System;
using FluentAssertions;
using Fyley.Components.Financial.Domain.Shared;
using Fyley.Components.Financial.Domain.Shared.Errors;
using Xunit;

namespace Fyley.Components.Financial.Tests.Domain.Shared
{
    // ReSharper disable ObjectCreationAsStatement
    public class AccountNameTests
    { 
        public class ConstructorShould : AccountNameTests
        {
            [Fact]
            public void ThrowArgumentNullException_WhenValueIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() => 
                    new AccountName(null));

                exception.ParamName.Should().Be("value");
            }

            [Fact]
            public void ThrowAccountNameToLong_WhenNameToLong()
            {
                var exception = Assert.Throws<AccountNameToLong>(() => 
                    new AccountName("abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz"));
                
                exception.Message.Should().Contain("is to long");
            }

            [Fact]
            public void NotChangeValue()
            {
                // Act
                var accountName = new AccountName("Some account name");
                
                // Assert
                accountName.Value.Should().Be("Some account name");
            }
        }

        public class EqualShould : AccountNameTests
        {
            [Fact]
            public void Equal()
            {
                // Arrange
                var accountName1 = new AccountName("Some account name");
                var accountName2 = new AccountName("Some account name");
                
                // Act
                var result = accountName1.Equals(accountName2);

                // Assert
                result.Should().BeTrue();
            }
            
            [Fact]
            public void NotEqual()
            {
                // Arrange
                var accountName1 = new AccountName("Some account name");
                var accountName2 = new AccountName("Some other account name");
                
                // Act
                var result = accountName1.Equals(accountName2);

                // Assert
                result.Should().BeFalse();
            }
        }
    }
}