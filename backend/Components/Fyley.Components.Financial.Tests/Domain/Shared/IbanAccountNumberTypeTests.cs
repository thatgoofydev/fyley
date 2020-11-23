using Fyley.Components.Financial.Domain.Shared;
using NUnit.Framework;

namespace Fyley.Components.Financial.Tests.Domain.Shared
{
    [TestFixture]
    public class IbanAccountNumberTypeTests
    {
        public class ConstructorShould : OtherAccountNumberTypeTests
        {
            [Test]
            public void SetCorrectValues()
            {
                // Arrange + Act
                var accountType = AccountNumberType.Iban;
                
                // Assert
                Assert.That(accountType.Value, Is.EqualTo(2));
                Assert.That(accountType.Name, Is.EqualTo("Iban"));
            }
        }

        public class IsValidShould : OtherAccountNumberTypeTests
        {
            [Test]
            public void ReturnInvalid_WhenValueLengthToShort()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("a");

                // Arrange
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("length of at least"));
            }
            
            [Test]
            public void ReturnInvalid_WhenValueLengthToLong()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("abcdefghijklmnopqrstuvwxyz-abcdefghijklmnopqrstuvwxyz");

                // Arrange
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("maximum length"));
            }

            [Test]
            public void ReturnInvalid_WhenValueContainsNon_AlphanumericDashOrSpace_Character()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("TG624222--72 826 34 64@|11#9");

                // Arrange
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("alphanumeric"));
            }

            [Test]
            public void ReturnInvalid_WhenValueHasInvalidCountryCode()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("XX00 0000 0000 0000");
                
                // Arrange
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("not a valid country code"));
            }

            [Test]
            public void ReturnInvalid_WhenValueIsNotCorrectLengthForCountry()
            { // BE has length of 16
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("BE01 2345 6789 1011 1213 1415");
                
                // Arrange
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("should have a length of"));
            }

            [Test]
            public void ReturnValid()
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.IsValid("BE71485619235569");
                
                // Arrange
                Assert.That(result.IsValid, Is.True);
            }
        }

        public class FormatShould : OtherAccountNumberTypeTests
        {
            [TestCase("BE 71485  6192 35569", "BE71485619235569")]
            [TestCase("AD186 486244598698615  7513", "AD1864862445986986157513")]
            [TestCase("TG6242227 9723826434 864811179", "TG62422279723826434864811179")]
            public void StripSpacesFromValue(string inputValue, string expectedReturnValue)
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.Format(inputValue);

                // Arrange
                Assert.That(result, Is.EqualTo(expectedReturnValue));
            }
            
            [TestCase("BE-71485--6192-35569", "BE71485619235569")]
            [TestCase("AD186-486244598698615--7513", "AD1864862445986986157513")]
            [TestCase("TG6242227-9723826434-864811179", "TG62422279723826434864811179")]
            public void StripDashesFromValue(string inputValue, string expectedReturnValue)
            {
                // Arrange
                var accountType = AccountNumberType.Iban;
                
                // Act
                var result = accountType.Format(inputValue);

                // Arrange
                Assert.That(result, Is.EqualTo(expectedReturnValue));
            }
        }
    }
}