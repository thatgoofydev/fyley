using FluentAssertions;
using Fyley.Components.Financial.Domain.Accounts;
using Xunit;

namespace Fyley.Components.Financial.Tests.Domain.Accounts
{
    public class AccountDescriptionTests
    {
        public class ConstructorShould
        {
            [Theory]
            [InlineData("name", "name")]
            [InlineData(null, null)]
            public void SetValue(string value, string expected)
            {
                // Act
                var result = new AccountDescription(value);
                
                // Assert
                result.Value.Should().Be(expected);
            }
        }
    }
}