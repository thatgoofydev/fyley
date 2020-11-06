using System;
using System.Collections.Generic;
using Fyley.Components.Accounts.Domain;
using Fyley.Components.Accounts.Domain.Errors;
using NUnit.Framework;

namespace Fyley.Components.Accounts.Tests.Domain
{
    [TestFixture]
    public class AccountNumberTests
    {
        
        public class EqualsShould : AccountNumberTests
        {
            private static IEnumerable<TestCaseData> ShouldEqualTestData
            {
                get
                {
                    yield return new TestCaseData(
                        new AccountNumber(AccountNumberType.Other, "some-account-id"),
                        new AccountNumber(AccountNumberType.Other, "some-account-id"));
                    yield return new TestCaseData(
                        new AccountNumber(AccountNumberType.Iban, "BE43663898875201"),
                        new AccountNumber(AccountNumberType.Iban, "BE43 6638 9887 5201"));
                }
            }
        
            [Test, TestCaseSource(nameof(ShouldEqualTestData))]
            public void ReturnTrue(AccountNumber one, AccountNumber two)
            {
                var result = one.Equals(two);
                Assert.True(result);
            }            
        }

        public class ConstructorShould : AccountNumberTests
        {
            [Test]
            public void ThrowArgumentNullException_WhenTypeNull()
            {
                Assert.Throws<ArgumentNullException>(() =>
                    new AccountNumber(null, "somevalue"));
            }
            
            [Test]
            public void ThrowArgumentNullException_WhenValueNull()
            {
                Assert.Throws<ArgumentNullException>(() =>
                    new AccountNumber(AccountNumberType.Other, null));
            }
            
            [Test]
            public void ThrowInvalidAccountNumber_WhenAccountNumberIsInvalidForType()
            {
                Assert.Throws<InvalidAccountNumber>(() =>
                    new AccountNumber(AccountNumberType.Iban, "some-totally-invalid"));
            }

            [Test]
            public void NotThrow()
            {
                Assert.DoesNotThrow(() => 
                    new AccountNumber(AccountNumberType.Iban, "BE88798861555841"));
            }

            [Test]
            public void SetCorrectValues()
            {
                var result = new AccountNumber(AccountNumberType.Iban, "BE88798861555841");
                Assert.That(result.Type, Is.EqualTo(AccountNumberType.Iban));
                Assert.That(result.Value, Is.EqualTo(AccountNumberType.Iban.Format("BE88798861555841")));
            }
            
        }
    }
}