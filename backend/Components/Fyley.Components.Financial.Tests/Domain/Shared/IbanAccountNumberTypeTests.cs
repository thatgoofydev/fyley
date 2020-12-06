using FluentAssertions;
using Fyley.Components.Financial.Domain.Shared;
using Xunit;

namespace Fyley.Components.Financial.Tests.Domain.Shared
{
    public class IbanAccountNumberTypeTests
    {
        public class ConstructorShould : IbanAccountNumberTypeTests
        {
            [Fact]
            public void SetCorrectValues()
            {
                // Arrange + Act
                var accountType = AccountNumberType.Iban;
                
                // Assert
                accountType.Value.Should().Be(2);
                accountType.Name.Should().Be("Iban");
                
            }
        }

        public class IsValidShould : IbanAccountNumberTypeTests
        {
            [Fact]
            public void ReturnInvalid_WhenValueLengthToShort()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("a");

                // Arrange
                result.IsValid.Should().BeFalse();
                result.Error.Should().Contain("length of at least");
            }
            
            [Fact]
            public void ReturnInvalid_WhenValueLengthToLong()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz");

                // Arrange
                result.IsValid.Should().BeFalse();
                result.Error.Should().Contain("maximum length");
            }

            [Fact]
            public void ReturnInvalid_WhenValueContainsNon_AlphanumericDashOrSpace_Character()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("TG624222--72 826 34 64@|11#9");

                // Arrange
                result.IsValid.Should().BeFalse();
                result.Error.Should().Contain("alphanumeric");
            }

            [Fact]
            public void ReturnInvalid_WhenValueHasInvalidCountryCode()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("XX00 0000 0000 0000");
                
                // Arrange
                result.IsValid.Should().BeFalse();
                result.Error.Should().Contain("not a valid country code");
            }

            [Fact]
            public void ReturnInvalid_WhenValueIsNotCorrectLengthForCountry()
            { // BE has length of 16
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("BE01 2345 6789 1011 1213 1415");
                
                // Arrange
                result.IsValid.Should().BeFalse();
                result.Error.Should().Contain("should have a length of");
            }

            [Fact]
            public void ReturnValid()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("BE71485619235569");
                
                // Arrange
                result.IsValid.Should().BeTrue();
            }
        }

        public class FormatShould : IbanAccountNumberTypeTests
        {
            [Theory]
            [InlineData("BE 71485  6192 35569", "BE71485619235569")]
            [InlineData("AD186 486244598698615  7513", "AD1864862445986986157513")]
            [InlineData("TG6242227 9723826434 864811179", "TG62422279723826434864811179")]
            public void StripSpacesFromValue(string inputValue, string expectedReturnValue)
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.Format(inputValue);

                // Arrange
                result.Should().Be(expectedReturnValue);
            }
            
            [Theory]
            [InlineData("BE-71485--6192-35569", "BE71485619235569")]
            [InlineData("AD186-486244598698615--7513", "AD1864862445986986157513")]
            [InlineData("TG6242227-9723826434-864811179", "TG62422279723826434864811179")]
            public void StripDashesFromValue(string inputValue, string expectedReturnValue)
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.Format(inputValue);

                // Arrange
                result.Should().Be(expectedReturnValue);
            }
        }
    }
}