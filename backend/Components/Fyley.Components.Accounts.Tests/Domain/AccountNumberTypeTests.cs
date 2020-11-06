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

            [TestCase("", "")]
            [TestCase("test", "test")]
            public void Format_ShouldReturnInput(string input, string expectedOutput)
            {
                var result = AccountNumberType.Other.Format(input);
                Assert.That(result, Is.EqualTo(expectedOutput));
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

            [TestCase("BE43663898875201", "BE43 6638 9887 5201")]
            [TestCase("NL18RABO3831267707", "NL18 RABO 3831 2677 07")]
            [TestCase("HU77109180013534179746911573", "HU77 1091 8001 3534 1797 4691 1573")]
            [TestCase("BR3254274185863838743133472Y3", "BR32 5427 4185 8638 3874 3133 472Y 3")]
            [TestCase("LC66TJCT285256978619516477412846", "LC66 TJCT 2852 5697 8619 5164 7741 2846")]
            public void Format_ShouldFormatCorrectly(string input, string expectedOutput)
            {
                var result = AccountNumberType.Iban.Format(input);
                Assert.That(result, Is.EqualTo(expectedOutput));
            }
        }
    }
}