using Fyley.Components.Accounts.Domain;
using NUnit.Framework;

namespace Fyley.Components.Accounts.Tests.Domain
{
    [TestFixture]
    public class AccountNumberTypeTests
    {
        public class OtherAccountNumberType : AccountNumberTypeTests
        {
            [Test]
            public void ShouldHaveId_1()
            {
                Assert.That(AccountNumberType.Other.Value, Is.EqualTo(1));
            }
            
            [TestCase("yes its valid")]
            [TestCase("something like this might be valid as well")]
            [TestCase("Its literally just some value, because of countries that don't use iban")]
            public void IsValid_ShouldAlwaysReturnValid(string value)
            {
                var result = AccountNumberType.Other.IsValid(value);
                Assert.That(result.IsValid, Is.True);
            }
        }
        
        public class IbanAccountNumberType  : AccountNumberTypeTests
        {
            [Test]
            public void ShouldHaveId_2()
            {
                Assert.That(AccountNumberType.Iban.Value, Is.EqualTo(2));
            }

            [Test]
            public void IsValid_ShouldReturnInValidAndNonAlphanumericError()
            {
                var result = AccountNumberType.Iban.IsValid("BE48 6638 7628 6#@7");
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("alphanumeric"));
            }

            [Test]
            public void IsValid_ShouldReturnInValidForMinValue()
            {
                var result = AccountNumberType.Iban.IsValid("BE48");
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("length of at least"));
            }

            [Test]
            public void IsValid_ShouldReturnInValidForMaxValue()
            {
                var result = AccountNumberType.Iban.IsValid("BE48154875487544455646587452132154878915662154487945646211");
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("maximum length"));
            }

            [Test]
            public void IsValid_ShouldReturnInValidForCountryValue()
            {
                var result = AccountNumberType.Iban.IsValid("XX48 1514 1245 1245");
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("is not a valid country code"));
            }

            [Test]
            public void IsValid_ShouldReturnInValidForCountryWrongLengthValue()
            {
                var result = AccountNumberType.Iban.IsValid("BE05 9575 3789 37");
                Assert.That(result.IsValid, Is.False);
                Assert.That(result.Error, Contains.Substring("should have a length of"));
            }

            [TestCase("BE43 6638 9887 5201")]
            [TestCase("BE43663898875201")]
            public void IsValid_ShouldReturnValid(string value)
            {
                var result = AccountNumberType.Iban.IsValid(value);
                Assert.That(result.IsValid, Is.True);
            }

            [Test]
            public void Format_ShouldRemoveAllSpaces()
            {
                var result = AccountNumberType.Iban.Format("BE43 6638 9887 5201");
                Assert.That(result, Is.EqualTo("BE43663898875201"));
            }
        }
    }
}